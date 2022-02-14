using Kosha.DataLayer.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using Entity = Kosha.DataLayer;

namespace Kosha.Core.Services.AuthenticationCode
{
    public class AuthenticationCodeService : IAuthenticationCodeService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthenticationCodeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Entity.AuthenticationCode authenticationCode)
        {
            await _dbContext.AuthenticationCode.AddAsync(authenticationCode);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> IsValid(string number, string code)
        {
            var model = _dbContext.AuthenticationCode
                .FirstOrDefault(x => x.Number == number &&
                x.Code == code &&
                x.IsActive &&
                !x.IsUsed &&
                x.ExpireDate <= DateTime.Now);

            if (model is null)
                return false;

            model.IsUsed = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
