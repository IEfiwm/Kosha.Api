using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using FishHoghoghi.Structure;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Net.Http;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    [KoshaAuthorize]
    public class InfoController : BaseController
    {
        private readonly IUserContract _userContract;

        public InfoController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        [Route("Info/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                string token = GetToken();

                var result = _userContract.GetUserByToken(token);

                if (result == null || !CheckLock())
                    return Common.SetErrorResponse(System.Net.HttpStatusCode.Unauthorized, "اطلاعات لاگین اشتباه است.");

                //result.PhoneNumber = Info.GetPhoneNumber();

                return Common.Response(result);
            }
            catch (Exception e)
            {
                Common.Log(e);

                return Common.SetIntervalErrorResponse();
            }
        }

        private static bool CheckLock()
        {
            return true;
        }
    }
}