using Entity=Kosha.DataLayer;
using System.Threading.Tasks;
using Kosha.DataLayer;
using System.Collections.Generic;

namespace Kosha.Core.Services.Imported
{
    public interface IImportedService
    {
        Task<List<Kosha_Summary>> GetAllByProjectId(string year, string month, long projectId);

    }
}
