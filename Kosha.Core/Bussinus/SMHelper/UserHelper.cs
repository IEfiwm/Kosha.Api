using Kosha.Core.Bussinus.SMHelper.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class UserHelper : IUserHelper
    {
        public DataRow GetUserByNumber(string number, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM [identity].Users where PhoneNumber = N'{number}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
    }
}
