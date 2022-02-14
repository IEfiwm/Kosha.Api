using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Contract.Bank
{
    public class BankContract : IBankContract
    {
        private readonly IUserHelper _userHelper;

        public BankContract(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }
        public void TXTBank(int year, int month, long projectId)
        {
            //get employees with project id
            _userHelper.GetUsersByProjectId(projectId, out DataTable table);
            if (table == null)
                return ;

            var users = new List<UserViewModel>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                users.Add(new UserViewModel
                {
                    Id = table.Rows[i]["Id"].ToString(),
                    AccountNumber = table.Rows[i]["AccountNumber"].ToString(),
                    ProjectRef = projectId,
                    BankId = Convert.ToInt64(table.Rows[i]["BankId"]?.ToString()),
                });
            }

            //get payment of each employee and join with account number

            //////

            //group by bankId and create list of bankId
            var bankAccountsProject = new List<BankAccountViewModel>();

            var bankIdList = users.GroupBy(x => x.BankId).Select(x => x.Key).ToList();

            //get account number of project
            foreach (var bankId in bankIdList)
            {
                _userHelper.GetAccountsByProjectIdAndBankId(projectId, bankId, out DataTable bankAccountTabel);

                if (bankAccountTabel == null)
                    continue;

                bankAccountsProject.Add(new BankAccountViewModel
                {
                    AccountNumber = bankAccountTabel.Rows[0]["AccountNumber"].ToString(),
                    BankId = bankId,
                    ProjectId = projectId
                });
            }


            //foreach in users   
            foreach (var user in users)
            {
                switch (user.BankId)
                {
                    case (1):
                        {
                            break;
                        }

                }
            }

            //create txt file based on bank id

            //zip files and delete files and folder  

            //return zip 
            //return new HttpResponseMessage();

        }


        private void ShahrTXTBank(List<UserViewModel> users, string bankAccountNumber)
        {
            string fileName = @"C:\Temp\Shahr.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("1");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                    fs.Write(author, 0, author.Length);
                }

                

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
