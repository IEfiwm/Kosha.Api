using Kosha.Core.Bussinus.SMHelper.Provider;
using System.Data;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class UserHelper : IUserHelper
    {

        public DataRow GetUserById(string userId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT  * FROM Kosha_Users
                    WHERE UserId =  N'{userId}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public DataRow GetUserByNumber(string number, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT  * FROM Kosha_Users
                    WHERE PhoneNumber = N'{number}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public DataRowCollection GetUsersByProjectId(long projectId,int year,long month, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT * From Kosha_UserProjects
                                    WHERE projectRef = N'{projectId}' AND ماه=N'{month}' AND [سال ]=N'{year}'  ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows;
        }


        public DataRow GetAccountsByProjectIdAndBankId(long projectId, long bankId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM Kosha_ProjectBankAccount 
                                                    WHERE ProjectId = N'{projectId}' AND BankId = N'{bankId}'");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

    }
}
