using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using FishHoghoghi.Structure;
using FishHoghoghi.Structure.Models;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using Common = FishHoghoghi.Utilities.Utility;

namespace FishHoghoghi.Controllers
{
    public class CalculationController : BaseController
    {
        private readonly IUserContract _userContract;

        public CalculationController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        [Route("Calculation/GenerateSalary/{projectId}/{year}/{month}")]
        [HttpGet]
        public HttpResponseMessage GenerateSalary(long projectId, string year, string month)
        {

            var fieldFormules = Project.GetFieldRules(projectId);
            List<FieldRuleModel> model = new List<FieldRuleModel>();
            string command = "";
            var insertQuery = " insert into Data.TbImported (year,month,";

            for (int i = 0, count = fieldFormules.Rows.Count; i < count--; i++)
            {
                model.Add(new FieldRuleModel
                {
                    Name = fieldFormules.Rows[i]["Name"]?.ToString(),
                    Alias = fieldFormules.Rows[i]["Alias"]?.ToString(),
                    Formule = fieldFormules.Rows[i]["Formule"]?.ToString()
                });
            }


            foreach (var item in model)
            {
                item.Formule = cal(item.Formule, model);
            }

            foreach (var item in model)
            {
                command += $@"{item.Formule.Replace("&", "")}  AS  [{item.Name}],";
                insertQuery += item.Name + ",";
            }


            command = command.Remove(command.Length - 1);
            insertQuery = insertQuery.Remove(insertQuery.Length - 1);
            insertQuery += ") ";


            insertQuery += $@"SELECT	 {year},{month},{command} FROM	[dbo].[Kosha_Attendances] 
                    WHERE   [ProjectId] =   {projectId}    AND [سال]   = '{year}'    AND [ماه] =   '{month}'";


            //delete from imported
            //insert 

            return null;
        }

        private string cal(string formule, List<FieldRuleModel> model)
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
                            formule = cal(formule, model);
                        }
                    }
                }
            }
            return formule;
        }
    }
}