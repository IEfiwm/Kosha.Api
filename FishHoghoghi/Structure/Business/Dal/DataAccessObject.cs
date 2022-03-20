using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FishHoghoghi.Dal
{
    public static class DataAccessObject
    {

        public static DataTable ExecuteCommand(string command, string connectionName = "Sg3ConnectionString")
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ToString()))
            {
                var ds = new DataSet();

                new SqlDataAdapter(command, connection).Fill(ds);

                return ds.Tables.Count == 0 ? null : ds.Tables[0];
            }
        }
    }
}