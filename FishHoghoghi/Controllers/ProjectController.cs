using FishHoghoghi.Attribute;
using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    [KoshaAuthorize]
    public class ProjectController : ApiController
    {
        private readonly IUserContract _userContract;
        private readonly IProjectHelper _projectHelper;

        public ProjectController(IUserContract userContract, IProjectHelper projectHelper)
        {
            _userContract = userContract;
            _projectHelper = projectHelper;
        }

        [HttpGet]
        public HttpResponseMessage GetProject()
        {
            try
            {
                string token = Request.Headers.Authorization?.Parameter;

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
    }
}