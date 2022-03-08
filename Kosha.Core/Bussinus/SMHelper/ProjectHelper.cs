using Kosha.Core.Bussinus.SMHelper.Provider;
using System.Data;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class ProjectHelper : IProjectHelper
    {
        public DataRow GetById(long projectId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM [dbo].[Kosha_Project] WHERE Id =  N'{projectId}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
    }
}
