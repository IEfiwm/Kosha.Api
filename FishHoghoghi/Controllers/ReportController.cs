using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Utilities;
using FishHoghoghi.Models;
using Newtonsoft.Json;
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
using System.Web.Http;
using TaxLib.Base.Model;
using static Stimulsoft.Base.StiJsonReportObjectHelper;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    public class ReportController : ApiController
    {
        public ReportController()
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn0s4gy0Fr5YoUZ9V00Y0igCSFQzwEqYBh/N77k4f0fWXTHW5rqeBNLkaurJDenJ9o97TyqHs9HfvINK18Uwzsc/bG01Rq+x3H3Rf+g7AY92gvWmp7VA2Uxa30Q97f61siWz2dE5kdBVcCnSFzC6awE74JzDcJMj8OuxplqB1CYcpoPcOjKy1PiATlC3UsBaLEXsok1xxtRMQ283r282tkh8XQitsxtTczAJBxijuJNfziYhci2jResWXK51ygOOEbVAxmpflujkJ8oEVHkOA/CjX6bGx05pNZ6oSIu9H8deF94MyqIwcdeirCe60GbIQByQtLimfxbIZnO35X3fs/94av0ODfELqrQEpLrpU6FNeHttvlMc5UVrT4K+8lPbqR8Hq0PFWmFrbVIYSi7tAVFMMe2D1C59NWyLu3AkrD3No7YhLVh7LV0Tttr/8FrcZ8xirBPcMZCIGrRIesrHxOsZH2V8t/t0GXCnLLAWX+TNvdNXkB8cF2y9ZXf1enI064yE5dwMs2fQ0yOUG/xornE";

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
            var projects = projectIds.Split(',');

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

        //[HttpGet]
        //[Route("Report/TXTTaxAll/{year}/{month}")]
        //public HttpResponseMessage TXTTaxAll(int year, int month, string projectIds)
        //{
        //    var projects = projectIds.Split(',');

        //    var report = new StiReport();

        //    var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TaxAll.mrt");

        //    report.Load(path);

        //    var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];

        //    dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

        //    report.Dictionary.Variables["Month"].ValueObject = month;

        //    report.Dictionary.Variables["Year"].ValueObject = year;

        //    report.Dictionary.Variables["ProjectRef"].ValueObject = projectId;

        //    report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

        //    var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

        //    return response;
        //}

        [HttpPost]
        [Route("Report/TXTTaxSummary")]
        public HttpResponseMessage TXTTaxSummary(MKModel model)
        {
            var context = new TaxLib.Tax();

            context.Path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/TXT/");

            var resfile = context.GenerateWK(model);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Utility.StreamFile(resfile.FilePath))
            };

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = resfile.FilePath.Split('/').Last()
            };

            File.Delete(resfile.FilePath);

            return result;
        }
    }
}