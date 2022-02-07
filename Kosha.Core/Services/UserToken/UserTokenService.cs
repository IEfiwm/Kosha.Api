using Entity = Kosha.DataLayer;
using System.Threading.Tasks;
using Kosha.DataLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> ExpireTokensByUserId(string userId)
        {
            await _dbContext.UserTokens.Where(x => x.UserId == userId && x.IsUsed).ForEachAsync(entity =>
            {
                entity.IsUsed = true;
            });
            _dbContext.SaveChanges();
            return true;
        }

        public Entity.UserToken Get(string token)
        {
            return _dbContext.UserTokens.FirstOrDefault(x => x.Code == token);
        }
    }
}
