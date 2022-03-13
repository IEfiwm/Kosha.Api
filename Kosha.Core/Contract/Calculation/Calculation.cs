using System;
using System.Threading.Tasks;

namespace Kosha.Core.Contract.Calculation
{
    public class CalculationContract : ICalculationContract
    {
        public async Task<bool> GenerateSalary(long projectId, string year, string month)
        {
            try
            {

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
