using Kosha.Core.Common.Model;
using System.Threading.Tasks;

namespace Kosha.Core.Contract.AuthenticationCode
{
    public interface IUserContract
    {
        Task<byte> SendVerificationCodeByNumber(string number);

        Task<bool> VerifyByCode(string number, string code);

        Task<string> GenerateLoginTokenByNumber(string number);

        bool AuthorizeUserByToken(string token);

        UserViewModel GetUserByToken(string token);
    }
}
