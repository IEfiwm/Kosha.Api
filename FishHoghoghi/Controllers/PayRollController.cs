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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace Fish.Controllers
{
    [LockFilter]
    public class PayRollController : ApiController
    {
        #region Initialization

        private MemoryStream _memoryStream;

        private HttpResponseMessage _response;

        private ContentDispositionHeaderValue _attachment;

        private DataRow _user;

        private ReportViewModel _reportViewModel;

        private static string GetPublicDirectory(string username, int year, int month)
        {
            Common.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\{username}");

            Common.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\{username}\{year}");

            Common.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\{username}\{year}\{month}");

            return $@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\{username}\{year}\{month}\";
        }

        public PayRollController()
        {
            _memoryStream = new MemoryStream();

            _response = new HttpResponseMessage();
        }

        #endregion

        [HttpGet]
        [NoCache]
        public HttpResponseMessage Get(string username, string password, int year, int month)
        {
            try
            {
                var directory = GetPublicDirectory(username, year, month);

                var fileName = password + ".pdf";

                var filePath = directory + fileName;

                if (File.Exists(filePath) && File.GetLastWriteTime(filePath).Date < DateTime.Now.Date || ConfigurationManager.AppSettings["Cache"].ToString() == "false")
                {
                    File.Delete(filePath);
                }
                else if (File.Exists(filePath) && ConfigurationManager.AppSettings["Cache"].ToString() == "true")
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        file.CopyTo(_memoryStream);

                        file.Close();
                    }

                    _response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(_memoryStream.ToArray())
                    };

                    _attachment = new ContentDispositionHeaderValue("attachment");

                    _attachment.FileName = Guid.NewGuid().ToString("N").Remove(8) + ".pdf";

                    _response.Content.Headers.ContentDisposition = _attachment;

                    _response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                }

                _reportViewModel = CommonHelper.Deserialize<ReportViewModel>(CommonHelper.ReadJson("Jsons", "ReportRecords.json"));

                if (!(CommonHelper.IsAfterDate(year, month, _reportViewModel.limitYear, _reportViewModel.limitMonth) && CommonHelper.IsBeforeCurrentDate(year, month)))
                {
                    return Common.SetBadResponse();
                }

                if (LoginLogDao.IsLoginLimited(username, out int totalRequest))
                {
                    return Common.SetErrorResponse(HttpStatusCode.InternalServerError, $"limited request is terminate. {totalRequest} requsted executed.");
                }

                _user = FishHamkaran.GetUserFishHoghoghi(username, password, year.ToString(), CommonHelper.SetMonthFormat(month), out DataTable dataSource);

                if ((_user == null) || !CheckLock())
                {
                    return Common.SetErrorResponse(HttpStatusCode.NotFound, "در این تاریخ فیش حقوقی یافت نشد.");
                }

                GenerateFishReport(_user, dataSource, _reportViewModel).ExportToPdf(_memoryStream);

                _response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(_memoryStream.ToArray())
                };

                _attachment = new ContentDispositionHeaderValue("attachment");

                _attachment.FileName = Guid.NewGuid().ToString("N").Remove(8) + ".pdf";

                _response.Content.Headers.ContentDisposition = _attachment;

                _response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                LoginLogDao.AddLoginLog(username, Common.GetIPAddress());

                return _response;
            }
            catch (Exception exp)
            {
                Common.Log(exp);

                return Common.SetIntervalErrorResponse();
            }
        }

        [HttpGet]
        [NoCache]
        [Route("PayRoll/GetLink/{username}/{password}/{year}/{month}")]
        public HttpResponseMessage GetLink(string username, string password, int year, int month)
        {
            try
            {
                var directory = GetPublicDirectory(username, year, month);

                var fileName = password + ".pdf";

                var filePath = directory + fileName;

                if (File.Exists(filePath) && File.GetLastWriteTime(filePath).Date < DateTime.Now.Date || ConfigurationManager.AppSettings["Cache"].ToString() == "false")
                {
                    File.Delete(filePath);
                }
                else if (File.Exists(filePath) && ConfigurationManager.AppSettings["Cache"].ToString() == "true")
                {
                    return Common.Response(new { link = ConfigurationManager.AppSettings["HostName"].ToString() + $@"/Content/Files/{username}/{year}/{month}/" + password + ".pdf" });
                }

                _reportViewModel = CommonHelper.Deserialize<ReportViewModel>(CommonHelper.ReadJson("Jsons", "ReportRecords.json"));

                if (!(CommonHelper.IsAfterDate(year, month, _reportViewModel.limitYear, _reportViewModel.limitMonth) && CommonHelper.IsBeforeCurrentDate(year, month)))
                {
                    return Common.SetBadResponse();
                }

                if (LoginLogDao.IsLoginLimited(username, out int totalRequest))
                {
                    return Common.SetErrorResponse(HttpStatusCode.InternalServerError, $"limited request is terminate. {totalRequest} requsted executed.");
                }

                _user = FishHamkaran.GetUserFishHoghoghi(username, password, year.ToString(), CommonHelper.SetMonthFormat(month), out DataTable dataSource);

                if ((_user == null) || !CheckLock())
                {
                    return Common.SetErrorResponse(HttpStatusCode.NotFound, "در این تاریخ فیش حقوقی یافت نشد.");
                }

                GenerateFishReport(_user, dataSource, _reportViewModel).ExportToPdf(_memoryStream);

                using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
                {
                    _memoryStream.WriteTo(file);

                    file.Close();
                }

                LoginLogDao.AddLoginLog(username, Common.GetIPAddress());

                return Common.Response(new { link = ConfigurationManager.AppSettings["HostName"].ToString() + $@"/Content/Files/{username}/{year}/{month}/" + password + ".pdf" });
            }
            catch (Exception exp)
            {
                Common.Log(exp);

                return Common.SetIntervalErrorResponse();
            }
        }

        #region Utility

        private static bool CheckLock()
        {
            return true;
        }

        private Dictionary<string, string> GenerateColumn(DataRow row, NumberFormatInfo provider, List<SummaryFieldInfo> columnContent)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            columnContent.ForEach(field =>
            {
                if (field.IsString)
                {
                    string value = row.GetValueString(field.Name);

                    if (field.IsRequire)
                    {
                        dictionary.Add(field.Title, field.IsNumber ? value.ToPersianNumber() : value + field.Postfix);
                    }
                    else
                    {
                        if (value != null && value != "")
                        {
                            dictionary.Add(field.Title, field.IsNumber ? value.ToPersianNumber() : value + field.Postfix);
                        }
                    }
                }
                else if (field.IsDecimal)
                {
                    decimal value = row.GetDecimalValue(field.Name);

                    if (field.IsRequire)
                    {
                        dictionary.Add(field.Title, field.IsHourNumber ? value.ToPersianHourNumber() + field.Postfix : value.ToString("C", provider).ToPersianNumber() + field.Postfix);
                    }
                    else
                    {
                        if (value > 0)
                        {
                            dictionary.Add(field.Title, field.IsHourNumber ? value.ToPersianHourNumber() + field.Postfix : value.ToString("C", provider).ToPersianNumber() + field.Postfix);
                        }
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

            XRLabel Companylabel = null;

            if (userInfo != null && userInfo?.GetValueString("CompanyName") != "")
                Companylabel = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(320.5416f, 0f), "xrLabelCompany", new PaddingInfo(2, 2, 0, 10, 300f), new SizeF(150f, 0f), userInfo?.GetValueString("CompanyName"), false, 13f, FontStyle.Bold, reporModel.Setting.FontFamily));
            else
                Companylabel = XRDocumentExtentions.CreateLablel(new LabelModel(new PointFloat(320.5416f, 0f), "xrLabelCompany", new PaddingInfo(2, 2, 0, 10, 300f), new SizeF(150f, 0f), reporModel.Setting.CompanyName, false, 13f, FontStyle.Bold, reporModel.Setting.FontFamily));

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

        private void CreatePayRollBody(int MaxLength, XRTableRow cloumnHeaderRow, List<Dictionary<string, string>> columns, out XRTable child, string fontFamily = "Tahoma", float? fontSize = 8)
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
                if (field == "شماره حساب")
                {
                    Row.AddCell(userInfo.GetDecimalValue(field.Trim()).ToPersianNumber(), FontFamily, titleFontSize);

                    Row.AddCell(field.Trim(), FontFamily, textFontSize);
                }
                else
                {
                    Row.AddCell(userInfo.GetDecimalValue(field.Trim()).ToString("C", provider).ToPersianNumber(), FontFamily, titleFontSize);

                    Row.AddCell(field.Trim(), FontFamily, textFontSize);
                }
            });

            foreach (XRTableCell item in Row.Cells)
            {
                var Borders = index++ % 2 == 0 ? (BorderSide.Bottom | BorderSide.Top | BorderSide.Left) : (BorderSide.Bottom | BorderSide.Top | BorderSide.Right);

                item.SetStyle(Borders, TextAlignment.MiddleLeft, new PaddingInfo(2, 10, 0, 0));

            }

            table.Rows.Add(Row);

            return table;
        }

        #endregion
    }
}