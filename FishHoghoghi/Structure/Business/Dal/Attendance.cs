using FishHoghoghi.Dal;
using FishHoghoghi.Structure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FishHoghoghi.Structure.Business.Dal
{
    public static class Attendance
    {

        public static void DeleteImported(long projectId, string year, string month)
        {
            var res = DataAccessObject.ExecuteCommand($@"UPDATE DATA.TbImported SET IsDeleted=1 
                WHERE ProjectRef ={projectId} AND YEAR='{year}' AND MONTH='{month}'"
                , "SMConnectionString");

        }
        public static void InsertImported(string command)
        {
            var res = DataAccessObject.ExecuteCommand(command, "SMConnectionString");

        }

        public static string getFormula(string formule, List<FieldRuleModel> model)
        {
            Regex regex = new Regex(@"\[(?<Col>([^\[|\]]*))+\]$");
            var groups = formule.Split('&'); /// [staticField] & * & [dynamicField]
            if (groups.Length > 0)
            {
                foreach (var word in groups)
                {
                    if (word.Contains("["))// [dynamicField] 
                    {
                        Match getCol = regex.Match(word.Trim());
                        string col = getCol.Value?.Replace("[", "").Replace("]", "").Trim();//dynamicField

                        if (model.Any(x => x.Alias == col))
                        {
                            var childModel = model.FirstOrDefault(x => x.Alias == col);
                            formule = formule.Replace("[" + col + "]", "(" + childModel.Formule + ")");
                            formule = getFormula(formule, model);
                        }
                    }
                }
            }
            return formule;
        }
    }
}