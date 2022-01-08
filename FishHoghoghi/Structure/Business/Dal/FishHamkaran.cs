using System.Data;

namespace FishHoghoghi.Dal
{
    public static class FishHamkaran
    {
        public static DataRow GetUserFishHoghoghi(string username, string password, string year, string month, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"
SELECT
    *
FROM
    Kosha_PayRoll
WHERE
    [کد ملی] = N'{username}'
  AND
    [شماره حساب] = N'{password}'
  AND
    سال = {year}
  AND
    ماه = {month}");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
    }
}