using System.Threading.Tasks;
using Entity = Kosha.DataLayer;

namespace Kosha.Core.Services.AuthenticationCode
{
    public interface IAuthenticationCodeService
    {
        Task<bool> Create(Entity.AuthenticationCode authenticationCode);

        Task<bool> IsValid(string number, string code);

        Task<bool> HasActiveCode(string number);

        Task<bool> IsValidForGetCode(string number);

        Task SetAllCodeExpire(string number);
    }
}