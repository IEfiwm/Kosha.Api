using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Kosha.Core.Contract.Bank
{
    public interface IBankContract
    {
        void TXTBank(int year, int month, long projectId);
    }
}
