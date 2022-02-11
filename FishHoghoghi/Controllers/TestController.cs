using FishHoghoghi.Attribute;
using Kosha.Core.Common.Helper;
using Kosha.Core.Contract.AuthenticationCode;
using System.Web.Http;
using System.Web.Mvc;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    public class TestController : Controller
    {
        private readonly IUserContract _userContract;
        public TestController(IUserContract userContract)
        {
            _userContract = userContract;
        }
 
        [KoshaAuthorize]
        public void Index()
        {
            //_userContract.SendVerificationCodeByNumber("09108085966");
            //_userContract.VerifyByCode("09108085966", "37332");
            //_userContract.GenerateLoginTokenByNumber("09108085966");

        }
    }
}