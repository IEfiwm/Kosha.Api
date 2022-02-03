using Kosha.DataLayer.Context;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity = Kosha.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<Entity.AuthenticationCode> GetByNumberAndCode(string number, string code)
        {
            return _dbContext.AuthenticationCode.FirstOrDefault(x => x.Number == number && x.Code == code);
        }
    }
}
