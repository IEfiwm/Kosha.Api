using FishHoghoghi.Business.Utilities;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace FishHoghoghi.Controllers
{
    public class ReportController : ApiController
    {
        public ReportController()
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn0s4gy0Fr5YoUZ9V00Y0igCSFQzwEqYBh/N77k4f0fWXTHW5rqeBNLkaurJDenJ9o97TyqHs9HfvINK18Uwzsc/bG01Rq+x3H3Rf+g7AY92gvWmp7VA2Uxa30Q97f61siWz2dE5kdBVcCnSFzC6awE74JzDcJMj8OuxplqB1CYcpoPcOjKy1PiATlC3UsBaLEXsok1xxtRMQ283r282tkh8XQitsxtTczAJBxijuJNfziYhci2jResWXK51ygOOEbVAxmpflujkJ8oEVHkOA/CjX6bGx05pNZ6oSIu9H8deF94MyqIwcdeirCe60GbIQByQtLimfxbIZnO35X3fs/94av0ODfELqrQEpLrpU6FNeHttvlMc5UVrT4K+8lPbqR8Hq0PFWmFrbVIYSi7tAVFMMe2D1C59NWyLu3AkrD3No7YhLVh7LV0Tttr/8FrcZ8xirBPcMZCIGrRIesrHxOsZH2V8t/t0GXCnLLAWX+TNvdNXkB8cF2y9ZXf1enI064yE5dwMs2fQ0yOUG/xornE";

        }
        [HttpGet]
        [Route("Report/InsuranceAll/{year}/{month}")]
        public HttpResponseMessage InsuranceAll(int year, int month)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/InsuranceReportAll.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];
            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/InsuranceSummary/{year}/{month}")]
        public HttpResponseMessage InsuranceSummary(int year, int month)
        {
            var report = new StiReport();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/InsuranceReportSummary.mrt");

            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];
            dbMS_SQL.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;

            report.Dictionary.Variables["Month"].ValueObject = month;

            report.Dictionary.Variables["Year"].ValueObject = year;

            report.ReportName = Guid.NewGuid().ToString("N").Remove(8);

            var response = StiMvcReportResponse.ResponseAsPdf(report).ToHttpResponseMessage();

            return response;
        }

        [HttpGet]
        [Route("Report/DBFSummary/{year}/{month}")]
        public HttpResponseMessage DBFSummary(int year, int month)
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
                    da = new SqlDataAdapter(sCMD_All, myConn);
                    da.SelectCommand = myCommand;
                    da.Fill(ds, "DBF");
                    myConn.Close();
                }
            }
            var response = DBFCreator.DataSetIntoDBF("DSKKAR00", ds);

            //var response = Request.CreateResponse(HttpStatusCode.Moved);

            //response.Headers.Location = new Uri("http://www.google.com");

            return response;
        }

        [HttpGet]
        [Route("Report/DBFAll/{year}/{month}")]
        public HttpResponseMessage DBFAll(int year, int month)
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
                    da = new SqlDataAdapter(sCMD_All, myConn);
                    da.SelectCommand = myCommand;
                    da.Fill(ds, "DBF");
                    myConn.Close();
                }
            }
            var response = DBFCreator.DataSetIntoDBF("DSKWOR00", ds);

            //var response = Request.CreateResponse(HttpStatusCode.Moved);

            //response.Headers.Location = new Uri("http://www.google.com");

            return response;
        }

    }
}