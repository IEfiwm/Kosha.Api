using Entity = Kosha.DataLayer;
using System.Threading.Tasks;
using Kosha.DataLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Kosha.DataLayer;

namespace Kosha.Core.Services.Imported
{
    public class ImportedService : IImportedService
    {
        private readonly ApplicationDbContext _dbContext;
        public ImportedService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Kosha_Summary>> GetAllByProjectId(string year, string month, long projectId)
        {
            return await _dbContext.KoshaSummary.Where(x => x.ماه == month && x.سال == year && x.ProjectRef == projectId).ToListAsync();
        }
    }
}
