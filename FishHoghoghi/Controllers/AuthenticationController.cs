using FishHoghoghi.Attribute;
using FishHoghoghi.Structure;
using Kosha.Core.Contract.AuthenticationCode;
using System.Threading.Tasks;
using System.Web.Http;

namespace FishHoghoghi.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IUserContract _userContract;
        public AuthenticationController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        [HttpGet]
        [Route("Authentication/Login/{number}")]
        public async Task<bool> Login(string number)
        {
            return await _userContract.SendVerificationCodeByNumber(number);
        }

        [HttpGet]
        [Route("Authentication/VerifyByCode/{number}/{code}")]
        public async Task<string> VerifyByCode(string number, string code)
        {
            var res = await _userContract.VerifyByCode(number, code);
            
            if (res)
                return await _userContract.GenerateLoginTokenByNumber(number);
            
            return null;
        }
    }
}