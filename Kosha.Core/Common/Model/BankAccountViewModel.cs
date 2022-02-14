using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Common.Model
{
    public class BankAccountViewModel
    {
        public long BankId { get; set; }
        public long ProjectId { get; set; }
        public string AccountNumber { get; set; }
    }
}
