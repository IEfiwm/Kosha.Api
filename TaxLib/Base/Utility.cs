using System;
using System.IO;
using System.Text;
using TaxLib.Base.Model;

namespace TaxLib.Base
{
    public static class Utility
    {
        public static int DateTimeNowToInt()
        {
            return int.Parse(DateTimeNow());
        }

        public static string DateTimeNow()
        {
            System.Globalization.PersianCalendar perCalendar = new System.Globalization.PersianCalendar();

            var dtMilad = DateTime.Now;

            string month, day;

            if (perCalendar.GetMonth(dtMilad) < 10)
                month = "0" + perCalendar.GetMonth(dtMilad);
            else
                month = perCalendar.GetMonth(dtMilad).ToString();

            if (perCalendar.GetDayOfMonth(dtMilad) < 10)
                day = "0" + perCalendar.GetDayOfMonth(dtMilad);
            else
                day = perCalendar.GetDayOfMonth(dtMilad).ToString();

            return perCalendar.GetYear(dtMilad).ToString() + month + day;
        }

        public static string GetTowDigits(int digit)
        {
            if (digit < 10)
                return "0" + digit;
            else
                return digit.ToString();
        }

        public static bool CreateTextFile(string path, string txtFile)
        {
            try
            {
                bool exitFile = File.Exists(path);

                if (exitFile)
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(txtFile);

                    fs.Write(info, 0, info.Length);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string CreateWK(MKModel model)
        {
            return model.Year + ","
                  + model.Month + ","
                  + Math.Round(model.Debt, 0) + ","
                  + Math.Round(model.PreviousDebt, 0) + ","
                  + int.Parse(model.RegisteredYear + Utility.GetTowDigits(model.RegisteredMonth) + Utility.GetTowDigits(model.RegisteredDay)) + ","
                  + model.PaymentMethod + ","
                  + model.SerialCheck + ","
                  + int.Parse(model.CheckYear + Utility.GetTowDigits(model.CheckMonth) + Utility.GetTowDigits(model.CheckDay)) + ","
                  + model.BankIndex + ","
                  + model.BranchName + ","
                  + model.AccountNo + ","
                  + model.PaymentAmount + ","
                  + int.Parse(model.PaymentYear + Utility.GetTowDigits(model.PaymentMonth) + Utility.GetTowDigits(model.PaymentDay)) + ","
                  + model.PaymentAmountOfTreasury;
        }
    }
}
