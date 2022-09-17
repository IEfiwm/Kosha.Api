using FishHoghoghi.Business.Utilities;
using FishHoghoghi.Extentions;
using FishHoghoghi.Structure;
using FishHoghoghi.Structure.Business.Dal;
using FishHoghoghi.Utilities;
using Kosha.Core.Contract.Bank;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using TaxLib.Base.Model;
using PersianDateTime = MD.PersianDateTime.PersianDateTime;
using Utility = FishHoghoghi.Models.Utility;

namespace FishHoghoghi.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IBankContract _bankContract;

        public ReportController(IBankContract bankContract)
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn0s4gy0Fr5YoUZ9V00Y0igCSFQzwEqYBh/N77k4f0fWXTHW5rqeBNLkaurJDenJ9o97TyqHs9HfvINK18Uwzsc/bG01Rq+x3H3Rf+g7AY92gvWmp7VA2Uxa30Q97f61siWz2dE5kdBVcCnSFzC6awE74JzDcJMj8OuxplqB1CYcpoPcOjKy1PiATlC3UsBaLEXsok1xxtRMQ283r282tkh8XQitsxtTczAJBxijuJNfziYhci2jResWXK51ygOOEbVAxmpflujkJ8oEVHkOA/CjX6bGx05pNZ6oSIu9H8deF94MyqIwcdeirCe60GbIQByQtLimfxbIZnO35X3fs/94av0ODfELqrQEpLrpU6FNeHttvlMc5UVrT4K+8lPbqR8Hq0PFWmFrbVIYSi7tAVFMMe2D1C59NWyLu3AkrD3No7YhLVh7LV0Tttr/8FrcZ8xirBPcMZCIGrRIesrHxOsZH2V8t/t0GXCnLLAWX+TNvdNXkB8cF2y9ZXf1enI064yE5dwMs2fQ0yOUG/xornE";
            
            _bankContract = bankContract;
        }

        [HttpGet]
        [Route("Report/InsuranceAll/{year}/{month}/{projectId}")]
        public HttpResponseMessage InsuranceAll(int year, int month, long projectId)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/InsuranceReportAll.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.Dictionary.Variables["ProjectRef"].ValueObject = projectId;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/InsuranceSummary/{year}/{month}/{projectId}")]
        public HttpResponseMessage InsuranceSummary(int year, int month, long projectId)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/InsuranceReportSummary.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.Dictionary.Variables["ProjectRef"].ValueObject = projectId;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/DBFSummary/{year}/{month}/{projectId}")]
        public HttpResponseMessage DBFSummary(int year, int month, long projectId)
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            string sCMD_All = "dbo.ProcKosha_DSK";

            SqlDataAdapter da = new SqlDataAdapter();

            DataSet ds = new DataSet();

            using (SqlConnection myConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sCMD_All, myConn))
                {
                    myConn.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@year", SqlDbType.NVarChar).Value = year.ToString();
                    myCommand.Parameters.AddWithValue("@month", SqlDbType.NVarChar).Value = month.ToString();
                    myCommand.Parameters.AddWithValue("@projectId", SqlDbType.NVarChar).Value = projectId.ToString();
                    da = new SqlDataAdapter(sCMD_All, myConn);
                    da.SelectCommand = myCommand;
                    da.Fill(ds, "DBF");
                    myConn.Close();
                }
            }
            var response = DBFCreator.DataSetIntoDBF("DSKKAR00", ds, Models.TypeOfDBFFile.Summary);

            return response;
        }

        [HttpGet]
        [Route("Report/DBFAll/{year}/{month}/{projectId}")]
        public HttpResponseMessage DBFAll(int year, int month, long projectId)
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            string sCMD_All = "dbo.ProcKosha_DSW";

            SqlDataAdapter da = new SqlDataAdapter();

            DataSet ds = new DataSet();

            using (SqlConnection myConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sCMD_All, myConn))
                {
                    myConn.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@year", SqlDbType.NVarChar).Value = year.ToString();
                    myCommand.Parameters.AddWithValue("@month", SqlDbType.NVarChar).Value = month.ToString();
                    myCommand.Parameters.AddWithValue("@projectId", SqlDbType.NVarChar).Value = projectId.ToString();
                    da = new SqlDataAdapter(sCMD_All, myConn);
                    da.SelectCommand = myCommand;
                    da.Fill(ds, "DBF");
                    myConn.Close();
                }
            }
            var response = DBFCreator.DataSetIntoDBF("DSKWOR00", ds);

            return response;
        }

        [HttpGet]
        [Route("Report/TaxAll/{year}/{month}/{projectIds}")]
        public HttpResponseMessage TaxAll(int year, int month, string projectIds)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TaxReportAll.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.Dictionary.Variables["ProjectRef"].ValueObject = projectIds;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpPost]
        [Route("Report/TaxSummary")]
        public HttpResponseMessage TaxSummary(MKModel model)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TaxReportSummary.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["ProjectRef"].ValueObject = string.Join(",", model.projectList);

            report.Dictionary.Variables["Month"].ValueObject = model.Month;

            report.Dictionary.Variables["Year"].ValueObject = model.Year;

            report.Dictionary.Variables["Day"].ValueObject = model.Day;

            report.Dictionary.Variables["RegisteredYear"].ValueObject = model.RegisteredYear;

            report.Dictionary.Variables["RegisteredMonth"].ValueObject = model.RegisteredMonth;

            report.Dictionary.Variables["RegisteredDay"].ValueObject = model.RegisteredDay;

            report.Dictionary.Variables["Debt"].ValueObject = model.Debt;

            report.Dictionary.Variables["PreviousDebt"].ValueObject = model.PreviousDebt;

            report.Dictionary.Variables["SerialCheck"].ValueObject = model.SerialCheck;

            report.Dictionary.Variables["CheckYear"].ValueObject = model.CheckYear;

            report.Dictionary.Variables["CheckMonth"].ValueObject = model.CheckMonth;

            report.Dictionary.Variables["CheckDay"].ValueObject = model.CheckDay;

            report.Dictionary.Variables["BranchName"].ValueObject = model.BranchName;

            report.Dictionary.Variables["BankName"].ValueObject = model.BankName;

            report.Dictionary.Variables["AccountNo"].ValueObject = model.AccountNo;

            report.Dictionary.Variables["PaymentMethodStr"].ValueObject = model.PaymentMethodStr;

            report.Dictionary.Variables["PaymentAmount"].ValueObject = model.PaymentAmount;

            report.Dictionary.Variables["PaymentYear"].ValueObject = model.PaymentYear;

            report.Dictionary.Variables["PaymentMonth"].ValueObject = model.PaymentMonth;

            report.Dictionary.Variables["PaymentDay"].ValueObject = model.PaymentDay;

            report.Dictionary.Variables["PaymentAmountOfTreasury"].ValueObject = model.PaymentAmountOfTreasury;

            report.Dictionary.Variables["Non_surrender_penalty"].ValueObject = model.Non_surrender_penalty;

            report.Dictionary.Variables["Failure_to_pay"].ValueObject = model.Failure_to_pay;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/TXTTaxWPAll/{year}/{month}/{projectIds}")]
        public HttpResponseMessage TXTTaxWPAll(int year, int month, string projectIds)
        {
            var projects = projectIds.Split(',').Select(x => Convert.ToInt64(x)).ToList();

            var data = WP_WH.GetData(projects, year, month, out System.Data.DataTable dataSource);

            if (data == null)
            {
                return null;
            }

            var context = new TaxLib.Tax();

            context.Path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TXT/");

            var list = new List<PersonnelInfo>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                var item = data[i];

                PersianDateTime firstworkingdate = item[5].ToString() != null && item[5].ToString() != "" && item[5].ToString() != " " ? new PersianDateTime(DateTime.Parse(item[5].ToString())) : default(PersianDateTime);

                PersianDateTime endworkingdate = item[6].ToString() != null && item[6].ToString() != "" && item[6].ToString() != " " ? new PersianDateTime(DateTime.Parse(item[6].ToString())) : default(PersianDateTime);

                list.Add(new PersonnelInfo
                {
                    Name = item[0].ToString(),
                    LastName = item[1].ToString(),
                    NationalCode = item[2].ToString(),
                    JobTitle = item[3].ToString(),
                    ServiceLocation = item[4].ToString(),
                    FirstMonthWork = firstworkingdate.ToDateTime().Date.ToString("yyyy/MM") == DateTime.Now.Date.ToString("yyyy/MM") ? 1 : 2,
                    StartWorkingDate = CommonHelper.ConvertToEnglishNumber(firstworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", "")),
                    StartWorkDate = Convert.ToInt32(CommonHelper.ConvertToEnglishNumber(firstworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", ""))),
                    EndWorkingDate = endworkingdate == default(PersianDateTime) ? "" : CommonHelper.ConvertToEnglishNumber(endworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", "")),
                    EndWorkDate = endworkingdate == default(PersianDateTime) ? 0 : Convert.ToInt32(CommonHelper.ConvertToEnglishNumber(endworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", ""))),
                    EndMonthWork = endworkingdate == default(PersianDateTime) ? 2 : endworkingdate.ToDateTime().Date.ToString("yyyy/MM") == DateTime.Now.Date.ToString("yyyy/MM") ? 1 : 2,
                    InsurenceType = Convert.ToInt32(item[8].ToString()),
                    IncludedBenefits = Convert.ToInt32(item[9].ToString().Split('.')[0]),
                });

            }

            var resfile = context.GenerateWP(year, month, list);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Models.Utility.StreamFile(resfile.FilePath))
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = resfile.FilePath.Split('\\').Last()
            };

            File.Delete(resfile.FilePath);

            return result;
        }

        [HttpGet]
        [Route("Report/TXTTaxWHAll/{year}/{month}/{paymentMethod}/{projectIds}")]
        public HttpResponseMessage TXTTaxWHAll(int year, int month, int paymentMethod, string projectIds)
        {
            var projects = projectIds.Split(',').Select(x => Convert.ToInt64(x)).ToList();

            var data = WP_WH.GetData(projects, year, month, out System.Data.DataTable dataSource);

            if (data == null)
            {
                //return Common.SetBadResponse();
            }

            var context = new TaxLib.Tax();

            context.Path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TXT/");

            var list = new List<PersonnelInfo>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                var item = data[i];

                PersianDateTime firstworkingdate = item[5].ToString() != null && item[5].ToString() != "" && item[5].ToString() != " " ? new PersianDateTime(DateTime.Parse(item[5].ToString())) : default(PersianDateTime);

                PersianDateTime endworkingdate = item[6].ToString() != null && item[6].ToString() != "" && item[6].ToString() != " " ? new PersianDateTime(DateTime.Parse(item[6].ToString())) : default(PersianDateTime);

                list.Add(new PersonnelInfo
                {
                    Name = item[0].ToString(),
                    LastName = item[1].ToString(),
                    NationalCode = item[2].ToString(),
                    JobTitle = item[3].ToString(),
                    ServiceLocation = item[4].ToString(),
                    FirstMonthWork = firstworkingdate.ToDateTime().Date.ToString("yyyy/MM") == DateTime.Now.Date.ToString("yyyy/MM") ? 1 : 2,
                    StartWorkingDate = CommonHelper.ConvertToEnglishNumber(firstworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", "")),
                    StartWorkDate = Convert.ToInt32(CommonHelper.ConvertToEnglishNumber(firstworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", ""))),
                    EndWorkingDate = endworkingdate == default(PersianDateTime) ? "" : CommonHelper.ConvertToEnglishNumber(endworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", "")),
                    EndWorkDate = endworkingdate == default(PersianDateTime) ? 0 : Convert.ToInt32(CommonHelper.ConvertToEnglishNumber(endworkingdate.Date.ToString("yyyy/MM/dd").Replace("/", ""))),
                    EndMonthWork = endworkingdate == default(PersianDateTime) ? 2 : endworkingdate.ToDateTime().Date.ToString("yyyy/MM") == DateTime.Now.Date.ToString("yyyy/MM") ? 1 : 2,
                    InsurenceType = Convert.ToInt32(item[8].ToString()),
                    IncludedBenefits = Convert.ToInt32(item[9].ToString().Split('.')[0]),
                });

            }

            var resfile = context.GenerateWH(year, month, paymentMethod, list);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Models.Utility.StreamFile(resfile.FilePath))
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = resfile.FilePath.Split('\\').Last()
            };

            File.Delete(resfile.FilePath);

            return result;
        }

        [HttpPost]
        [Route("Report/TXTTaxSummary")]
        public HttpResponseMessage TXTTaxSummary(MKModel model)
        {
            var context = new TaxLib.Tax();

            var thismonth = WK.GetThisMonthData(model.projectList.Select(x => Convert.ToInt64(x)).ToList(), model.Year, model.Month, out System.Data.DataTable dataSource01);

            var allmonth = WK.GetAllMonthData(model.projectList.Select(x => Convert.ToInt64(x)).ToList(), model.Year, model.Month, out System.Data.DataTable dataSource02);

            model.Debt = Convert.ToInt64(thismonth[0].ToString());

            model.PreviousDebt = Convert.ToInt64(allmonth[0].ToString());

            context.Path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TXT/");

            var resfile = context.GenerateWK(model);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Models.Utility.StreamFile(resfile.FilePath))
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = resfile.FilePath.Split('\\').Last()
            };

            File.Delete(resfile.FilePath);

            return result;
        }

        [HttpGet]
        [Route("Report/BankTXT/{year}/{month}/{projectId}")]
        public async Task<HttpResponseMessage> TXTBank(int year, int month, long projectId)
        {
            var zipFilePath = await _bankContract.TXTBank(year, month, projectId);

            var fileName = "Banks_" + DateTime.Now.ToString("yyyy-MM-dd hh-mm") + ".zip";

            var zipFileName = zipFilePath + "_" + fileName + ".zip";

            if (File.Exists(zipFileName))
                File.Delete(zipFileName);

            ZipHelper.CreateZipFile(zipFilePath, zipFileName);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Utility.StreamFile(zipFileName))
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            foreach (FileInfo file in new DirectoryInfo(zipFilePath).GetFiles())
            {
                file.Delete();
            }

            foreach (var directory in new DirectoryInfo(zipFilePath).GetDirectories())
            {
                foreach (var file in directory.GetFiles())
                {
                    file.Delete();
                }
                directory.Delete();
            }

            Directory.Delete(zipFilePath);

            File.Delete(zipFileName);

            return result;
        }
       
        [HttpGet]
        [Route("Report/BankPDF/{year}/{month}/{projectId}")]
        public HttpResponseMessage PDFBank(int year, int month, long projectId)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/BankReportSummary.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.Dictionary.Variables["ProjectRef"].ValueObject = projectId;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/MySummary/{year}/{month}/{projectId}")]
        public HttpResponseMessage MySummary(int year, int month, long projectId)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/MySummary.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.Dictionary.Variables["ProjectRef"].ValueObject = projectId;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }
    }
}