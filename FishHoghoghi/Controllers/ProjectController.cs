using FishHoghoghi.Attribute;
using FishHoghoghi.Utilities;
using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Contract.AuthenticationCode;
using Kosha.Core.Contract.Imported;
using Kosha.Core.Services.Imported;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    //[KoshaAuthorize]
    public class ProjectController : ApiController
    {
        private readonly IUserContract _userContract;
        private readonly IProjectHelper _projectHelper;
        private readonly IImportedContract _importedContract;

        public ProjectController(IUserContract userContract, IProjectHelper projectHelper,
            IImportedContract importedContract)
        {
            _userContract = userContract;
            _projectHelper = projectHelper;
            _importedContract = importedContract;
        }

        [HttpGet]
        public HttpResponseMessage GetProject()
        {
            try
            {
                string token = Request.Headers.Authorization?.Scheme;

                var result = _userContract.GetUserByToken(token);

                if (result == null)
                    return Common.SetErrorResponse(System.Net.HttpStatusCode.Unauthorized, "اطلاعات لاگین اشتباه است.");

                _projectHelper.GetById(result.ProjectRef, out DataTable projectTable);

                if (projectTable == null)
                    return null;

                var model = new ProjectViewModel
                {
                    DisplayAddress = projectTable.Rows[0]["DisplayAddress"].ToString(),
                    DisplayEmail = projectTable.Rows[0]["DisplayEmail"].ToString(),
                    DisplayPhoneNumber = projectTable.Rows[0]["DisplayPhoneNumber"].ToString(),
                    DisplayPostalCode = projectTable.Rows[0]["DisplayPostalCode"].ToString(),
                    DisplayName = projectTable.Rows[0]["DisplayName"].ToString(),
                };

                return Common.Response(model);
            }
            catch (Exception e)
            {
                Common.Log(e);

                return Common.SetIntervalErrorResponse();
            }
        }

        [HttpGet]
        [Route("Project/GetStatusReport/{year}/{month}/{projectId}")]
        public async Task<HttpResponseMessage> GetStatusReport(string year, string month, long projectId)
        {
            try
            {
                var file = await _importedContract.GetStatusReportExcel(year, month, projectId);

                var bytes = file.ToArray();

                var res = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(bytes)
                };

                res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "StatusReport_" + month + ".xlsx"
                };

                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");

                return res;
            }
            catch (Exception e)
            {
                Common.Log(e);

                return Common.SetIntervalErrorResponse();
            }
        }
    }
}