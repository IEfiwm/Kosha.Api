using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Models;
using FishHoghoghi.Dal;
using FishHoghoghi.Extensions;
using FishHoghoghi.FishDataSetTableAdapters;
using FishHoghoghi.Models;
using FishHoghoghi.Utilities;
using Kosha.Core.Common.Helper;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Script.Serialization;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    public class ValuesController : ApiController
    {
        private readonly FishDataSet _fishDataSet;
        private readonly MKView_FishHamkaranTableAdapter _mKView_FishHamkaranTableAdapter;
        private readonly MKView_ContractHamkaranTableAdapter _mKView_ContractHamkaranTableAdapter;
        private readonly IUserContract _userContract;

        public ValuesController(IUserContract userContract)
        {
            _mKView_ContractHamkaranTableAdapter = new MKView_ContractHamkaranTableAdapter();

            _mKView_FishHamkaranTableAdapter = new MKView_FishHamkaranTableAdapter
            {
                ClearBeforeFill = true
            };

            _fishDataSet = new FishDataSet
            {
                DataSetName = "FishDataSet",

                SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
            };
            _userContract = userContract;

        }

        [KoshaAuthorize]
        public IHttpActionResult Get()
        {
            try
            {
                string token = Request.Headers.Authorization?.Parameter;

                var user = _userContract.GetUserByToken(token);

                if (user == null)
                    return Json(new
                    {
                        Status = false,

                        Message = "خطا در لاگین"
                    });

                string username = user.NationalCode;
                string password = user.AccountNumber;

                _mKView_FishHamkaranTableAdapter.FillByValidation(_fishDataSet.MKView_FishHamkaran, username, password);

                if ((_fishDataSet.MKView_FishHamkaran.Count == 0) || !CheckLock())
                {
                    var obj2 = new
                    {
                        Status = false,
                        Message = "اطلاعات لاگین اشتباه است."
                    };

                    return Json(new JavaScriptSerializer().Serialize(obj2));
                }

                _mKView_ContractHamkaranTableAdapter.Fill(_fishDataSet.MKView_ContractHamkaran, username);

                FishDataSet.MKView_FishHamkaranRow row = (FishDataSet.MKView_FishHamkaranRow)_fishDataSet.MKView_FishHamkaran.Rows[0];

                FishDataSet.MKView_ContractHamkaranRow row2 = (FishDataSet.MKView_ContractHamkaranRow)_fishDataSet.MKView_ContractHamkaran.Rows[0];

                string queryString = "SELECT * FROM [dbo].PortalSetting";

                string connectionString = ConfigurationManager.ConnectionStrings["NgraConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(queryString, connection);

                DataSet ds = new DataSet();

                new SqlDataAdapter(command).Fill(ds);

                string phoneNumber = ds.Tables[0].Rows[0]["PhoneNumberSupport"].ToString();

                var obj = new
                {
                    FirstName = row.نام,
                    LastNAme = row.نام_خانوادگی,
                    Occupation = row2.شغل,
                    Status = true,
                    PhoneNumber = phoneNumber
                };

                return Json(obj);
            }
            catch
            {
                return Json(new
                {
                    Status = false,

                    Message = "خطا در لاگین"
                });
            }
        }

        [NoCache]
        [KoshaAuthorize]
        public HttpResponseMessage Get(int year, int month)
        {
            try
            {
                string token = Request.Headers.Authorization?.Parameter;

                var userData = _userContract.GetUserByToken(token);

                if (userData == null)
                    return Common.SetErrorResponse(HttpStatusCode.Unauthorized, "اطلاعات لاگین اشتباه است.");

                string username = userData.NationalCode;
                string password = userData.AccountNumber;

                string reportJson = CommonHelper.ReadJson("Jsons", "ReportRecords.json");

                ReportViewModel ReportModel = CommonHelper.Deserialize<ReportViewModel>(reportJson);

                if (!(CommonHelper.IsAfterDate(year, month, ReportModel.limitYear, ReportModel.limitMonth) && CommonHelper.IsBeforeCurrentDate(year, month)))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"bad request.")
                    };
                }

                if (LoginLogDao.IsLoginLimited(username, out int totalRequest))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"limited request is terminate. {totalRequest} requsted executed.")
                    };
                }

                string monthFormat = CommonHelper.SetMonthFormat(month);

                DataRow user = FishHamkaran.GetUserFishHoghoghi(username, password, year.ToString(), monthFormat, out DataTable dataSource);

                if ((user == null) || !ValuesController.CheckLock())
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Can't find user.")
                    };
                }

                MemoryStream mem = new MemoryStream();

                XtraReport report = GenerateFishReport(user, dataSource, ReportModel);

                report.ExportToPdf(mem);

                HttpResponseMessage message1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(mem.ToArray())
                };

                HttpResponseMessage result = message1;

                ContentDispositionHeaderValue HeaderValue = new ContentDispositionHeaderValue("attachment");


                HeaderValue.FileName = string.Concat("report-", year.ToString(), "-", monthFormat, ".pdf");

                result.Content.Headers.ContentDisposition = HeaderValue;

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                LoginLogDao.AddLoginLog(username, Utilities.Utility.GetIPAddress());

                return result;
            }
            catch (Exception exp)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(exp.Message + Environment.NewLine + exp.InnerException?.Message + Environment.NewLine + exp.InnerException?.InnerException?.Message)
                };
            }
        }

        [HttpGet]
        public IHttpActionResult Setting()
        {
            string queryString = "SELECT * FROM [dbo].PortalSetting";

            string connectionString = ConfigurationManager.ConnectionStrings["NgraConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(queryString, connection);

            SqlDataAdapter da = new SqlDataAdapter(command);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int phoneNumberSupport = int.Parse(ds.Tables[0].Rows[0]["PhoneNumberSupport"].ToString());

            var obj2 = new
            {
                phoneNumber = phoneNumberSupport
            };

            return Json(obj2);
        }

        private static bool CheckLock()
        {
            return true;
        }

        private Dictionary<string, string> GenerateColumn(DataRow row, NumberFormatInfo provider, List<SummaryFieldInfo> columnContent)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            columnContent.ForEach(field =>
            {
                decimal value = row.GetDecimalValue(field.Name);

                if (field.IsRequire)
                {
                    dictionary.Add(field.Title, field.IsHourNumber ? value.ToPersianHourNumber() : value.ToString("C", provider).ToPersianNumber() + field.Postfix);
                }
                else
                {
                    if (value > 0)
                    {
                        dictionary.Add(field.Title, field.IsHourNumber ? value.ToPersianHourNumber() : value.ToString("C", provider).ToPersianNumber() + field.Postfix);

                    }
                }
            });

            return dictionary;
        }

        private XtraReport GenerateFishReport(DataRow userInfo, DataTable dataSource, ReportViewModel reporModel)
        {
            XRTableRow ColumnHeaderRow = new XRTableRow();

            List<Dictionary<string, string>> Columns = new List<Dictionary<string, string>>();

            NumberFormatInfo provider = new NumberFormatInfo();

            provider.SetCurrencyInfo(0, ".", ",", "");

            XtraReport report = new XtraReport();

            report.SetStyle(true, false, new Font(reporModel.Setting.FontFamily, 8f), new Margins(0x10, 0x1a, 100, 100));

            report.SetDataSource(dataSource);

            ColumnHeaderRow.SetHeaderItem(reporModel.Report, reporModel.Setting.FontFamily, reporModel.Setting.BodyTitleFontSize);

            reporModel.Report.ForEach(col =>
            {
                Columns.Add(GenerateColumn(userInfo, provider, reporModel.Report.FirstOrDefault(r => r.Title == col.Title.Trim()).Contents));
            });

            int MaxColumnLength = Columns.Max(x => x.Count);

            CreatePayRollBody(MaxColumnLength, ColumnHeaderRow, Columns, out XRTable child, reporModel.Setting.FontFamily, reporModel.Setting.BodyContentFontSize);

            XRLabel Companylabel = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(320.5416f, 0f), "xrLabelCompany", new PaddingInfo(2, 2, 0, 10, 300f), new SizeF(150f, 0f), reporModel.Setting.CompanyName, false, 13f, FontStyle.Bold, reporModel.Setting.FontFamily));

            Companylabel.StylePriority.UseTextAlignment = true;

            XRLabel label2 = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(326.0417f, 10.00001f), "xrLabel21", new PaddingInfo(2, 2, 0, 0, 100f), new SizeF(62.49991f, 23f), "سال", reporModel.Setting.HeaderTitleFontSize, FontStyle.Bold, reporModel.Setting.FontFamily));

            XRLabel label3 = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(251.0417f, 10.00001f), "xrLabel22", new PaddingInfo(2, 2, 0, 0, 100f), new SizeF(75.00003f, 23f), userInfo.GetValueString("سال").ToPersianNumber(), reporModel.Setting.HeaderFontSize, null, reporModel.Setting.FontFamily));

            XRLabel label4 = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(465.9166f, 10.00001f), "xrLabel19", new PaddingInfo(2, 2, 0, 0, 100f), new SizeF(114.5833f, 23f), "فیش حقوق ماه", reporModel.Setting.HeaderTitleFontSize, FontStyle.Bold, reporModel.Setting.FontFamily));

            XRLabel label5 = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(388.5416f, 10.00001f), "xrLabel20", new PaddingInfo(2, 2, 0, 0, 100f), new SizeF(77.37503f, 23f), CommonHelper.GetMonthLabel(userInfo.GetValueString("ماه")), reporModel.Setting.HeaderFontSize, null, reporModel.Setting.FontFamily));

            XRTable HeaderTable = new XRTable();

            HeaderTable.SetStyleTable(new SizeF(803f, 15f), TextAlignment.MiddleCenter, Color.LightGray);

            HeaderTable.SetLocation(new PointFloat(0f, 40.875f));

            XRTableRow HeaderRow = new XRTableRow();

            reporModel.Header.ForEach(field =>
            {
                var value = field.Trim() != "نام و نام خانوادگی" ? userInfo.GetValueString(field.Trim()) : userInfo.GetValueString("نام") + " " + userInfo.GetValueString("نام خانوادگی");

                HeaderRow.AddCell(value, reporModel.Setting.FontFamily, reporModel.Setting.HeaderTitleFontSize);

                HeaderRow.AddCell(field.Trim(), reporModel.Setting.FontFamily, reporModel.Setting.HeaderFontSize);
            });

            int index = 0;

            foreach (XRTableCell item in HeaderRow.Cells)
            {
                var Borders = index++ % 2 == 0 ? (BorderSide.Bottom | BorderSide.Top | BorderSide.Left) : (BorderSide.Bottom | BorderSide.Top | BorderSide.Right);

                item.SetStyle(Borders, TextAlignment.MiddleLeft, new PaddingInfo(2, 10, 0, 0));

            }

            HeaderTable.AddRow(HeaderRow);

            XRTable subHeaderTable, FooterTable, subFooterTable;

            CreateTable(userInfo, provider, new PointFloat(0f, 65.9584f), new SizeF(803f, 15f), reporModel.SubHeader, reporModel.Setting.FontFamily, reporModel.Setting.HeaderTitleFontSize, reporModel.Setting.HeaderFontSize, null, out subHeaderTable);

            CreateTable(userInfo, provider, new PointFloat(0f, 15f * (MaxColumnLength + 1f) + 105f), new SizeF(602.2501f, 20f), reporModel.Footer, reporModel.Setting.FontFamily, reporModel.Setting.FooterTitleFontSize, reporModel.Setting.FooterFontSize, Color.LightGray, out FooterTable);

            CreateTable(userInfo, provider, new PointFloat(0f, 15f * (MaxColumnLength + 1f) + 130f), new SizeF(803f, 15f), reporModel.SubFooter, reporModel.Setting.FontFamily, reporModel.Setting.FooterTitleFontSize, reporModel.Setting.FooterFontSize, null, out subFooterTable);

            report.SetBands(new XRControl[] { Companylabel, label4, label5, label2, label3, subHeaderTable, child, HeaderTable, FooterTable, subFooterTable });

            return report;
        }

        public void CreatePayRollBody(int MaxLength, XRTableRow cloumnHeaderRow, List<Dictionary<string, string>> columns, out XRTable child, string fontFamily = "Tahoma", float? fontSize = 8)
        {
            child = new XRTable();

            child.SetStyleTable(new SizeF(803f, 15 * (MaxLength + 1)), TextAlignment.MiddleCenter, null);

            child.SetLocation(new PointFloat(0f, 100f));

            cloumnHeaderRow.SetCellBorder(BorderSide.All);

            child.AddRow(cloumnHeaderRow);

            for (int i = 0; i < MaxLength; i++)
            {
                XRTableRow row = new XRTableRow();

                for (int j = columns.Count - 1; j >= 0; j--)
                {
                    Dictionary<string, string> item = columns[j];

                    row.Cells.Add(XRDocumentExtentions.GenerateCell(i < item.Count ? item[item.Keys.ElementAt(i)] : string.Empty, false, 1.0, false, fontFamily, fontSize));

                    row.Cells.Add(XRDocumentExtentions.GenerateCell(i < item.Count ? item.Keys.ElementAt(i) : string.Empty, true, 1.0, false, fontFamily, fontSize));

                    /*row.AddCell(i < item.Count ? item[item.Keys.ElementAt(i)] : string.Empty, fontFamily, fontSize);

                    row.AddCell(i < item.Count ? item.Keys.ElementAt(i) : string.Empty, fontFamily, fontSize);
*/
                    row.SetPadding(new PaddingInfo(0, 0, 5, 5));

                    child.AddRow(row);

                }
            }
            foreach (XRControl control2 in child.Rows[child.Rows.Count - 1].Cells)
            {
                control2.Borders = BorderSide.Bottom | control2.Borders;
            }
            //foreach (XRTableCell Cell in child.Rows[child.Rows.Count - 1].Cells)
            //{
            //    Cell.SetBorder(BorderSide.Bottom | Cell.Borders);
            //}

        }

        private XRTable CreateTable(DataRow userInfo, NumberFormatInfo provider, PointFloat locationTable, SizeF sizeTable, List<string> list, string FontFamily, float? titleFontSize, float? textFontSize, Color? backColor, out XRTable table)
        {
            int index = 0;

            table = new XRTable();

            table.SetStyleTable(sizeTable, TextAlignment.MiddleCenter, backColor);

            table.SetLocation(locationTable);

            XRTableRow Row = new XRTableRow();

            list.ForEach(field =>
            {
                Row.AddCell(userInfo.GetDecimalValue(field.Trim()).ToString("C", provider).ToPersianNumber(), FontFamily, titleFontSize);

                Row.AddCell(field.Trim(), FontFamily, textFontSize);

            });

            foreach (XRTableCell item in Row.Cells)
            {
                var Borders = index++ % 2 == 0 ? (BorderSide.Bottom | BorderSide.Top | BorderSide.Left) : (BorderSide.Bottom | BorderSide.Top | BorderSide.Right);

                item.SetStyle(Borders, TextAlignment.MiddleLeft, new PaddingInfo(2, 10, 0, 0));

            }

            table.Rows.Add(Row);

            return table;
        }
    }
}