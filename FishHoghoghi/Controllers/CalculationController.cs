using FishHoghoghi.Business.Dal;
using FishHoghoghi.Structure;
using FishHoghoghi.Structure.Business.Dal;
using FishHoghoghi.Structure.Models;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
            if (Attendance.CheckExistsRequests(projectId, year, month))
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            
            Attendance.InsertRequest(projectId, year, month);

            var fieldFormules = Project.GetFieldRules(projectId);
            List<FieldRuleModel> model = new List<FieldRuleModel>();
            string command = "";
            var insertQuery = " insert into Data.TbImported (year,month,projectRef,IsDeleted,CreateDate,";

            for (int i = 0; i < fieldFormules.Rows.Count; i++)
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
                var myTask = Task.Run(() => Attendance.getFormula(item.Formule, model));

                if (myTask.Wait(TimeSpan.FromSeconds(30)))
                {
                    item.Formule = myTask.Result;
                }
                else
                {
                    throw new Exception("");
                }
            }

            foreach (var item in model)
            {
                command += $@"{item.Formule.Replace("&", "")}  AS  [{item.Name}],";
                insertQuery += item.Name + ",";
            }


            command = command.Remove(command.Length - 1);
            insertQuery = insertQuery.Remove(insertQuery.Length - 1);
            insertQuery += ") ";


            insertQuery += $@"SELECT	 {year} as year,{month} as month,{projectId} as projectRef,0,'{DateTime.Now}',{command} FROM	[Kosha_MTJA].[dbo].[Kosha_Attendances]  
                    WHERE   [ProjectId] =   {projectId}    AND [سال]   = '{year}'    AND [ماه] =   '{month}'";


            Attendance.DeleteImported(projectId, year, month);

            Attendance.InsertImported(insertQuery);

            return new HttpResponseMessage(HttpStatusCode.OK); ;

        }
    }
}