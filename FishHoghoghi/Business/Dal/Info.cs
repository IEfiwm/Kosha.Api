using FishHoghoghi.Dal;
using System.Data;

namespace FishHoghoghi.Business.Dal
{
    public class Info
    {
        public static DataRow GetUser(string username, string password, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"
SELECT  *
FROM    Kosha_LoginInfo
WHERE
    [کد ملی] = N'{username}'
  AND
    [شماره حساب] = N'{password}'");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public static string GetPhoneNumber()
        {
            var table = DataAccessObject.ExecuteCommand($@"SELECT * FROM [dbo].[PortalSetting]");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0].ItemArray[1].ToString();
        }
    }
}