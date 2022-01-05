using FishHoghoghi.Dal;
using System.Data;

namespace FishHoghoghi.Business.Dal
{
    public static class Contract
    {
        public static DataRow GetUserContract(string username, long projectId, out DataTable table)
        {
            if (projectId != default(long))
            {
                table = DataAccessObject.ExecuteCommand($@"
            SELECT
                *
            FROM
                [dbo].[Kosha_Contract]
            WHERE
                [کد ملی] = N'{username}'    AND [ProjectRef]    =   {projectId}");
            }
            else
            {
                table = DataAccessObject.ExecuteCommand($@"
            SELECT
                *
            FROM
                [dbo].[Kosha_Contract]
            WHERE
                [کد ملی] = N'{username}'");
            }

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return table.Rows[0];
        }
    }
}