using Entity=Kosha.DataLayer;
using System.Threading.Tasks;

namespace Kosha.Core.Services.UserToken
{
    public interface IUserTokenService
    {
        Task<bool> Create(Entity.UserToken userToken);
        Task<bool> ExpireTokensByUserId(string userId);
        Entity.UserToken Get(string token);
    }
}
