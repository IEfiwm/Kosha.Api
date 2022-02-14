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
        public DataRow GetUserById(string userId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT  * FROM [identity].Users
                    INNER JOIN
                    Basic.TbBankAccount ON TbBankAccount.Id = [Identity].Users.BankAccountRef
                    WHERE [identity].Users.Id =  N'{userId}' AND [identity].[Users].[IsDeleted] =   0   AND [identity].[Users].[IsActive]  =   1");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public DataRow GetUserByNumber(string number, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM [SM].[identity].Users WHERE PhoneNumber = N'{number}'    AND [IsDeleted] =   0   AND [IsActive]  =   1 ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
    }
}
