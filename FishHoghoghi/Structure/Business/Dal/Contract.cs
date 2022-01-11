using FishHoghoghi.Dal;
using System.Data;

namespace FishHoghoghi.Business.Dal
{
    public static class Contract
    {
        public static DataRow GetUserContract(string username, long projectId, out DataTable table, string startdate = null, string enddate = null, string duration = null)
        {
            var command = "";

            if (startdate != null && enddate != null && duration != null)
                command = $@"                    
                    SELECT
                        *,
                    N'{startdate.Replace("/", "-")}'  AS  [شروع قرارداد],
                    N'{enddate.Replace("/", "-")}'    AS  [پایان قرارداد],
                    N'{duration} ماه'   AS  [مدت]
                    FROM
                        [dbo].[Kosha_Contract]
                    WHERE";
            else
                command = $@"                    
                    SELECT
                        *
                    FROM
                        [dbo].[Kosha_Contract]
                    WHERE";

            if (projectId != default(long))
                command += $@"[کد ملی] = N'{username}'    AND [ProjectRef]    =   {projectId}";
            else
                command += $@"[کد ملی] = N'{username}'";

            table = DataAccessObject.ExecuteCommand(command);

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return table.Rows[0];
        }
    }
}