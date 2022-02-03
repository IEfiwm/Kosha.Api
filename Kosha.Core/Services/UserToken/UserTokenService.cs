using Entity = Kosha.DataLayer;
using System.Threading.Tasks;
using Kosha.DataLayer.Context;

namespace Kosha.Core.Services.UserToken
{
    public class UserTokenService : IUserTokenService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserTokenService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Entity.UserToken userToken)
        {
            await _dbContext.UserTokens.AddAsync(userToken);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
