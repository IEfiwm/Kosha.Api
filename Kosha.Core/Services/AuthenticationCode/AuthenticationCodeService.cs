using Kosha.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task SetAllCodeExpire(string number)
        {
            var model = await _dbContext.AuthenticationCode
                .Where(m => m.Number == number)
                .ToListAsync();

            model.ForEach(m =>
            {
                m.IsActive = false;
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsValid(string number, string code)
        {
            var model = await _dbContext.AuthenticationCode
                .FirstOrDefaultAsync(x => x.Number == number &&
                x.Code == code &&
                x.IsActive &&
                !x.IsUsed &&
                x.ExpireDate >= DateTime.Now);

            if (model is null)
                return false;

            model.IsUsed = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HasActiveCode(string number)
        {
            var model = await _dbContext.AuthenticationCode
                .AnyAsync(x => x.Number == number &&
                 x.IsActive &&
                 !x.IsUsed &&
                 x.ExpireDate >= DateTime.Now);

            return model;
        }

        public async Task<bool> IsValidForGetCode(string number)
        {
            var model = await _dbContext.AuthenticationCode
                .AsNoTracking()
                .Where(m => !m.IsUsed && DateTime.Now.AddHours(-3) < m.CreateDate && m.Number == number)
                .ToListAsync();

            return model.Count > 3;
        }
    }
}
