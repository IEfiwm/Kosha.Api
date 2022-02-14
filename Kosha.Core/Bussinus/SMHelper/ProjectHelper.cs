using Kosha.Core.Bussinus.SMHelper.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class ProjectHelper : IProjectHelper
    {
        public DataRow GetById(long projectId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM Basic.TbProject WHERE Id =  N'{projectId}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

 
    }
}
