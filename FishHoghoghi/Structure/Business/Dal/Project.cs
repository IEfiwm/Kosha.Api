using FishHoghoghi.Dal;
using System.Data;

namespace FishHoghoghi.Business.Dal
{
    public class Project
    {
        public static DataTable GetRules(long projectId)
        {
            var table = DataAccessObject.ExecuteCommand($@"SELECT	* FROM [dbo].[Kosha_ProjectRule] WHERE   [ProjectId] =   {projectId}");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0].Table;
        }        
        
        public static DataTable GetFields()
        {
            var table = DataAccessObject.ExecuteCommand($@"SELECT   	*   FROM   [dbo].[Kosha_Field]");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0].Table;
        }

         
        public static DataTable GetFieldRules(long projectId)
        {
           // var table = DataAccessObject.ExecuteCommand($@"SELECT	* FROM	[dbo].[Kosha_FieldRules] WHERE   [ProjectId] =   {projectId} or [ProjectId] = 0 ");
            var table = DataAccessObject.ExecuteCommand($@"SELECT	* FROM	Kosha_F_FieldRules({projectId})");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0].Table;
        }


        public static DataTable GetAttendances(long projectId, string year, string month,string formula)
        {
            var table = DataAccessObject.ExecuteCommand($@"SELECT	 {formula} FROM	[dbo].[Kosha_Attendances]WHERE   [ProjectId] =   {projectId}    AND [سال]   = '{year}'    AND [ماه] =   '{month}'");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0].Table;
        }
    }
}