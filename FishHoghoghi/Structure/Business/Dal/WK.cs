using FishHoghoghi.Dal;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FishHoghoghi.Structure.Business.Dal
{
    public static class WK
    {
        public static DataRow GetAllMonthData(List<long> projectId, int year, int month, out DataTable table)
        {
            var command = "";
            command += $@"                    
                    SELECT	SUM(CONVERT(DECIMAL,[ماليات]))
                    FROM
                       [dbo].[Kosha_Source01]
                    WHERE  [ماه] <= {month} AND [سال]  =   {year}";

            var index = projectId.Count - 1;

            command += "AND (";

            foreach (var item in projectId)
            {
                command += $@"[ProjectRef] =  {item}";

                if (index != 0)
                    command += "    OR ";

                index--;
            }

            command += ")";

            table = DataAccessObject.ExecuteCommand(command);

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return table.Rows[0];
        }

        public static DataRow GetThisMonthData(List<long> projectId, int year, int month, out DataTable table)
        {
            var command = "";
            command += $@"                    
                    SELECT	SUM(CONVERT(DECIMAL,[ماليات]))
                    FROM
                       [dbo].[Kosha_Source01]
                    WHERE  [ماه] = {month} AND [سال]  =   {year}";

            var index = projectId.Count - 1;

            command += "AND (";

            foreach (var item in projectId)
            {
                command += $@"[ProjectRef] =  {item}";

                if (index != 0)
                    command += "    OR ";

                index--;
            }

            command += ")";

            table = DataAccessObject.ExecuteCommand(command);

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return table.Rows[0];
        }
    }
}