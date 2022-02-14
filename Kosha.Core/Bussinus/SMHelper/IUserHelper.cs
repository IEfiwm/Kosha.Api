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

        DataRow GetUserById(string userId, out DataTable table);

        DataRowCollection GetUsersByProjectId(long projectId, out DataTable table);

        DataRow GetAccountsByProjectIdAndBankId(long projectId, long bankId, out DataTable table);
    }
}
