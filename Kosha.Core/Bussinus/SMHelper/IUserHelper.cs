using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Bussinus.SMHelper
{
    public interface IUserHelper
    {
        DataRow GetUserByNumber(string number, out DataTable table);
    }
}
