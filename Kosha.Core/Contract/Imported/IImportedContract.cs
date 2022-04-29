using System.IO;
using System.Threading.Tasks;

namespace Kosha.Core.Contract.Imported
{
    public interface IImportedContract
    {
        Task<MemoryStream> GetStatusReportExcel(string year, string month, long projectId);
    }
}
