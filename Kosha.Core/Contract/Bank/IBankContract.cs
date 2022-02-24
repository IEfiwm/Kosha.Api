using System.Threading.Tasks;

namespace Kosha.Core.Contract.Bank
{
    public interface IBankContract
    {
        Task<string> TXTBank(int year, int month, long projectId);
    }
}
