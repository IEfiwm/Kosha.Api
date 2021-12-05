using System;
using System.Data;

namespace FishHoghoghi.Dal
{
    public static class LoginLogDao
    {
        public static bool IsLoginLimited(string userName, out int totalRequest)
        {
            var dt = DataAccessObject.ExecuteCommand("SELECT COUNT(UserName) AS [Count] FROM [dbo].LoginLog GROUP BY UserName");

            totalRequest = dt.Rows.Count;

            var dt2 = DataAccessObject.ExecuteCommand("SELECT COUNT(UserName) AS [Count] FROM [dbo].LoginLog WHERE UserName='" + userName.Replace("-", "") + "'");

            return totalRequest > 1000 && dt2.Rows.Count == 0;
        }

        public static void AddLoginLog(string username, string ip)
        {
            DataAccessObject.ExecuteCommand($"INSERT dbo.LoginLog(username,login_at,mac_address)values('{username}','{DateTime.Now}','{ip}')");
        }
    }
}