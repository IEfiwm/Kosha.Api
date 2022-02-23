using Kosha.Core.Bussinus.SMHelper.Provider;
using System.Data;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class UserHelper : IUserHelper
    {

        public DataRow GetUserById(string userId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT  * FROM [identity].Users
                    INNER JOIN
                    Basic.TbBankAccount ON TbBankAccount.Id = [Identity].Users.BankAccountRef
                    WHERE [identity].Users.Id =  N'{userId}' AND [identity].[Users].[IsDeleted] =   0   AND [identity].[Users].[IsActive]  =   1 ");

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

        public DataRowCollection GetUsersByProjectId(long projectId,int year,long month, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT [identity].Users.*,bankId,Basic.TbBankAccount.AccountNumber,[كل حقوق و مزايا] as Salary FROM [identity].Users INNER JOIN
                                    Basic.TbBankAccount ON TbBankAccount.Id = [Identity].Users.BankAccountRef
                                    INNER JOIN Kosha_MTJA.dbo.Kosha_Source01 ON Kosha_MTJA.dbo.Kosha_Source01.[کد ملی ] = [Identity].Users.NationalCode
                                    where [identity].Users.projectRef = N'{projectId}' AND ماه=N'{month}' AND [سال ]=N'{year}' AND
                                     [identity].[Users].[IsDeleted] =0  AND Basic.TbBankAccount.[IsDeleted] =   0  AND BankId is not null ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows;
        }


        public DataRow GetAccountsByProjectIdAndBankId(long projectId, long bankId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM Basic.TbProjectBankAccount 
                                                    JOIN Basic.TbBank_Account on Bank_AccountId=TbBank_Account.Id
                                                    WHERE ProjectId = N'{projectId}' AND BankId = N'{bankId}' 
                                                     AND Basic.TbBank_Account.[IsDeleted] =0  AND Basic.TbProjectBankAccount.[IsDeleted] =   0 ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

    }
}
