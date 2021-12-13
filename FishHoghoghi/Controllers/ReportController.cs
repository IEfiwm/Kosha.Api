using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishHoghoghi.Controllers
{
    public class ReportController : Controller
    {
        public ReportController()
        {
            Stimulsoft.Base.StiLicense.Key =
                "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn0s4gy0Fr5YoUZ9V00Y0igCSFQzwEqYBh/N77k" +
                "4f0fWXTHW5rqeBNLkaurJDenJ9o97TyqHs9HfvINK18Uwzsc/bG01Rq+x3H3Rf+g7AY92gvWmp7VA2Ux" +
                "a30Q97f61siWz2dE5kdBVcCnSFzC6awE74JzDcJMj8OuxplqB1CYcpoPcOjKy1PiATlC3UsBaLEXsok1" +
                "xxtRMQ283r282tkh8XQitsxtTczAJBxijuJNfziYhci2jResWXK51ygOOEbVAxmpflujkJ8oEVHkOA/C" +
                "jX6bGx05pNZ6oSIu9H8deF94MyqIwcdeirCe60GbIQByQtLimfxbIZnO35X3fs/94av0ODfELqrQEpLr" +
                "pU6FNeHttvlMc5UVrT4K+8lPbqR8Hq0PFWmFrbVIYSi7tAVFMMe2D1C59NWyLu3AkrD3No7YhLVh7LV0" +
                "Tttr/8FrcZ8xirBPcMZCIGrRIesrHxOsZH2V8t/t0GXCnLLAWX+TNvdNXkB8cF2y9ZXf1enI064yE5dw" +
                "Ms2fQ0yOUG/xornE";
        }
        // GET: Report
        public ActionResult InsuranceAll()
        {

            var report = new StiReport();
            var path = StiNetCoreHelper.MapPath(this, "Reports/InsuranceReportAll.mrt");
            report.Load(path);

            var dbMS_SQL = (StiSqlDatabase)report.Dictionary.Databases["MS SQL"];
            dbMS_SQL.ConnectionString = @"Data Source=2.144.243.200;Initial Catalog=Kosha_MTJA;User Id=ngra;Password=ngra@123456789;MultipleActiveResultSets=True;";

            return StiNetCoreReportResponse.ResponseAsPdf(report);
        }
    }
}