using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public async Task<string> TXTBank(int year, int month, long projectId)
        {
            try
            {

                _userHelper.GetUsersByProjectId(projectId, year, month, out DataTable table);
                if (table == null)
                    return null;

                var zipFilePath = CreatePublicDirectoryBank();

                if (File.Exists(zipFilePath + ".zip"))
                {
                    File.Delete(zipFilePath + ".zip");
                }

                var users = new List<UserViewModel>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    try
                    {
                        users.Add(new UserViewModel
                        {
                            Id = table.Rows[i]["Id"].ToString(),
                            AccountNumber = table.Rows[i]["AccountNumber"].ToString(),
                            FirstName = table.Rows[i]["FirstName"].ToString(),
                            LastName = table.Rows[i]["LastName"].ToString(),
                            ProjectRef = projectId,
                            BankId = Convert.ToInt64(table.Rows[i]["BankId"]?.ToString()),
                            Salary = Convert.ToInt64(table.Rows[i]["Salary"]?.ToString()),
                        });
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                var bankAccountsProject = new List<BankAccountViewModel>();

                var bankIdList = users.GroupBy(x => x.BankId).Select(x => x.Key).ToList();

                foreach (var bankId in bankIdList)
                {
                    _userHelper.GetAccountsByProjectIdAndBankId(projectId, bankId, out DataTable bankAccountTabel);

                    if (bankAccountTabel == null || bankAccountTabel?.Rows.Count == 0)
                        continue;

                    bankAccountsProject.Add(new BankAccountViewModel
                    {
                        AccountNumber = bankAccountTabel.Rows[0]["AccountNumber"].ToString(),
                        BankId = bankId,
                        ProjectId = projectId
                    });
                }

                foreach (var item in bankAccountsProject)
                    await PrepareForTXTGenerators(users, bankAccountsProject, item.BankId);


                return zipFilePath;

            }
            catch (Exception x)
            {
                return null;
                throw;
            }
        }

        private async Task PrepareForTXTGenerators(List<UserViewModel> users, List<BankAccountViewModel> bankAccountsProject, long bankId)
        {
            switch (bankId)
            {
                case (32): //shahr
                    {
                        await Task.Run(() =>
                        {
                            var shahrUsers = users.Where(x => x.BankId == bankId && x.Salary > 0).ToList();
                            var shahrAcc = bankAccountsProject.FirstOrDefault(x => x.BankId == bankId);
                            if (shahrUsers.Count > 0 && shahrAcc != null)
                            {
                                ShahrTXTBank(shahrUsers, shahrAcc.AccountNumber, CreatePublicDirectory("Shahr"));
                            }
                        });
                        break;
                    }
                case (52)://sina
                    {
                        await Task.Run(() =>
                        {
                            var sinaUsers = users.Where(x => x.BankId == bankId).ToList();
                            var sinaAcc = bankAccountsProject.FirstOrDefault(x => x.BankId == bankId);
                            if (sinaUsers.Count > 0 && sinaAcc != null)
                            {
                                SinaTXTBank(sinaUsers, sinaAcc.AccountNumber, CreatePublicDirectory("Sina"));
                            }
                        });
                        break;
                    }
                case (44)://parsian
                    {
                        await Task.Run(() =>
                        {
                            var parsianUsers = users.Where(x => x.BankId == bankId && x.Salary > 0).ToList();
                            var parsianAcc = bankAccountsProject.FirstOrDefault(x => x.BankId == bankId);
                            if (parsianUsers.Count > 0 && parsianAcc != null)
                            {
                                ParsianExcelBank(parsianUsers, parsianAcc.AccountNumber, CreatePublicDirectory("Parsian"));
                            }
                        });
                        break;
                    }

            }
        }

        private void ShahrTXTBank(List<UserViewModel> users, string bankAccountNumber, string directory)//32	شهر
        {

            try
            {
                var countAll = users.Count;
                var payAll = users.Sum(x => x.Salary);
                var filePath = directory + "//" + "Shahr.txt";

                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);

                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] txt = new UTF8Encoding(true).GetBytes("1," + countAll + "," + payAll);
                    fs.Write(txt, 0, txt.Length);

                    fs.Write(newline, 0, newline.Length);

                    txt = new UTF8Encoding(true).GetBytes(bankAccountNumber + "," + payAll + ",D");
                    fs.Write(txt, 0, txt.Length);

                    foreach (var user in users)
                    {
                        fs.Write(newline, 0, newline.Length);
                        byte[] author = new UTF8Encoding(true).GetBytes("");

                        author = new UTF8Encoding(true).GetBytes(user.AccountNumber + "," + user.Salary + "," + "C");

                        fs.Write(author, 0, author.Length);
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void SinaTXTBank(List<UserViewModel> users, string bankAccountNumber, string directory)//52	سینا
        {

            try
            {

                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                var countAll = users.Count;
                var payAll = users.Sum(x => x.Salary);
                var filePath = directory + "//" + "Sina.txt";

                // Create a new file     
                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] txt = new UTF8Encoding(true).GetBytes("N\t" + +countAll + "\t" + bankAccountNumber.GetAccountFormat() + "\t" + payAll);
                    fs.Write(txt, 0, txt.Length);

                    foreach (var user in users)
                    {
                        try
                        {
                            if (user.AccountNumber?.Length == 14)
                            {
                                fs.Write(newline, 0, newline.Length);
                                byte[] author = new UTF8Encoding(true).GetBytes("");

                                author = new UTF8Encoding(true).GetBytes(user.AccountNumber.GetAccountFormat() + "\t" + user.Salary);

                                fs.Write(author, 0, author.Length);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void ParsianExcelBank(List<UserViewModel> users, string bankAccountNumber, string directory)// 44 پارسیان
        {
            var filePath = directory + "//" + "Parsian.xlsx";

            ExportToExcel(users, new FileInfo(filePath));
        }
   
        private static string CreatePublicDirectoryBank()
        {
            string filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\Banks";

            if (!File.Exists(filePath))
                Directory.CreateDirectory(filePath);

            return filePath;
        }

        private static string CreatePublicDirectory(string bankId)
        {
            string filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\Banks\bank_{bankId}";

            if (Directory.Exists(filePath))
            {
                var files = Directory.GetFiles(filePath);

                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            
            Directory.CreateDirectory(filePath);

            return filePath;
        }       
      
        public void ExportToExcel(IEnumerable<UserViewModel> users, FileInfo targetFile)
        {
            using (var excelFile = new ExcelPackage(targetFile))
            {
                var model = users.Select(x => new { x.AccountNumber, x.Salary, Name = x.FirstName + " " + x.LastName }).ToList();

                var worksheet = excelFile.Workbook.Worksheets.Add("transfer");

                worksheet.Column(1).Width = 40;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 50;
                worksheet.Column(4).Width = 70;

                worksheet.Cells["A1"].Value = "Destination Deposit Number (Variz Be)";
                worksheet.Cells["B1"].Value = "Transfer Amount (Mablagh)";
                worksheet.Cells["C1"].Value = "Destination Note (Sharh)";
                worksheet.Cells["D1"].Value = "Please do not remove this first row. (Lotfan radife nokhost ra paak nafarmayid.)";

                worksheet.Cells["A2"].LoadFromCollection(Collection: model, PrintHeaders: false);

                var allCells = worksheet.Cells[2, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                var cellFont = allCells.Style.Font;
                cellFont.SetFromFont(new Font("B Nazanin", 11));
                
                excelFile.Save();
            }
        }
    }
}
