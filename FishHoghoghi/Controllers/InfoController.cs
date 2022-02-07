using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using Kosha.Core.Common.Helper;
using Kosha.Core.Contract.AuthenticationCode;
using Microsoft.Net.Http.Headers;
using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    //[LockFilter]
    [KoshaAuthorize]
    public class InfoController :  ApiController
    {
        private readonly IUserContract _userContract;

        public InfoController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                string token = Request.Headers.Authorization?.Parameter;
                
                var result = _userContract.GetUserByToken(token);
 
                if (result==null || !CheckLock())
                     return Common.SetErrorResponse(System.Net.HttpStatusCode.Unauthorized, "اطلاعات لاگین اشتباه است.");
 
                result.PhoneNumber = Info.GetPhoneNumber();
 
                return Common.Response(result);
            }
            catch (Exception e)
            {
                Common.Log(e);

                return Common.SetIntervalErrorResponse();
            }
        }

        #region Utility

        private static bool CheckLock()
        {
            return true;
        }

        #endregion
    }
}