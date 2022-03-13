using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using FishHoghoghi.Structure;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Contract.AuthenticationCode;
using System;
using System.Data;
using System.Net.Http;
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
            var rules = Project.GetRules(projectId);

            string command = ",";

            for (int i = 0, count = rules.Rows.Count; i < count--; i++, command += ",")
            {
                command += $@"{rules.Rows[i]["Rule"].ToString().Replace("&", "")}  AS  [{rules.Rows[i]["Name"]}]";
            }

            command = command.Remove(command.Length - 1);

            var fields = Project.GetFields();

            string fieldsCommand = "INSERT  INTO    [SM_Test].[Data].[TbField]  (";

            for (int i = 0, count = fields.Rows.Count; i < count--; i++, fieldsCommand += ",")
            {
                fieldsCommand += $@"{fields.Rows[i]["Name"].ToString()}";
            }

            fieldsCommand = fieldsCommand.Remove(fieldsCommand.Length - 1);

            fieldsCommand += ")";

            var attendances = Project.GetAttendances(projectId, year, month, command);

            for (int i = 0, count = attendances.Rows.Count; i < count--; i++)
            {
                var test = attendances.Rows[i][fields.Rows[i]["Alias"].ToString()];
            }

            //if (rules.Table.Rows.Count == 0 || attendances.Table.Rows.Count == 0)
            //{
            //    return null;
            //}
            return null;
        }
    }
}