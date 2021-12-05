using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    public class InfoController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string username, string password)
        {
            try
            {
                Info.GetUser(username, password, out DataTable user);

                if ((user.Rows.Count == 0) || !CheckLock())
                {
                    return Common.SetErrorResponse(System.Net.HttpStatusCode.Unauthorized, "اطلاعات لاگین اشتباه است.");
                }

                var result = new
                {
                    FirstName = user.Rows[0].ItemArray[0],
                    LastNAme = user.Rows[0].ItemArray[1],
                    Occupation = user.Rows[0].ItemArray[4],
                    Status = true,
                    PhoneNumber = Info.GetPhoneNumber()
                };

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