using Kosha.DataLayer.Context;

namespace Kosha.Core.Services.Caculation
{
    public class CalculationService : ICalculationService
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
