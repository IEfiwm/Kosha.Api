using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Kosha.Core.Bussinus.SMHelper.Provider
{
    public static class DataAccessObject
    {
        public static ConnectionStringSettingsCollection ConnectionStrings { get; set; }

        public static void Init(ConnectionStringSettingsCollection connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public static DataTable ExecuteCommand(string command)
        {
            return ExecuteCommand(command, "SMConnectionString");
        }

        public static DataTable ExecuteCommand(string command, string connectionName)
        {
            using (var connection = new SqlConnection(ConnectionStrings[connectionName].ToString()))
            {
                var ds = new DataSet();

                new SqlDataAdapter(command, connection).Fill(ds);

                return ds.Tables.Count == 0 ? null : ds.Tables[0];
            }
        }
    }
}