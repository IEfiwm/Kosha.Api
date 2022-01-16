using FishHoghoghi.Dal;
using System.Collections.Generic;
using System.Data;

namespace FishHoghoghi.Structure.Business.Dal
{
    public static class WP_WH
    {
        public static DataRowCollection GetData(List<long> projectId, int year, int month, out DataTable table)
        {
            var command = "";
            command += $@"                    
                    SELECT
                      [نام],[نام خانوادگی],[کد ملی ],[شغل],[نام شعبه],[تاریخ شروع کار],[تاریخ ترک کار],[ProjectRef],2	AS	[نوع بیمه],[جمع مزایا]
                    FROM
                       [dbo].[Kosha_Source01]
                    WHERE   [ماه]   =   {month} AND [سال]  =   {year}";

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

            return table.Rows;
        }
    }
}