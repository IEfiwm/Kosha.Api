using System.Data;

namespace Kosha.Core.Bussinus.SMHelper
{
    public interface IUserHelper
    {
        DataRow GetUserByNumber(string number, out DataTable table);

        DataRow GetUserById(string userId, out DataTable table);

        DataRowCollection GetUsersByProjectId(long projectId, int year, long month, out DataTable table);

        DataRow GetAccountsByProjectIdAndBankId(long projectId, long bankId, out DataTable table);
    }
}
