using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZarkiaIntegratedSystem_Tax
{
    public partial class frmSalTax : Form
    {
        public frmSalTax()
        {
            InitializeComponent();
        }

        private void frmSalTax_Load(object sender, EventArgs e)
        {


            cmbBack.SelectedIndex = cmbPardakht.SelectedIndex = 0;


            itbBedehiMaliyati.Value = itbBedehiMaliyatiGhabli.Value =
             itbShomareHesab.Value = itbMablaghePardakhti.Value = itbMablaghePardakhtiKhazaneh.Value = 0;
            itbSabtMonth.Value = itbSabtDay.Value = itbSabtYear.Value = itbCheckYear.Value = itbCheckMonth.Value = itbCheckDay.Value = itbTarikhPardakhtYear.Value = itbTarikhPardakhtMonth.Value = itbTarikhPardakhtDay.Value = 0;
            cmbPardakht.SelectedIndex = 1;
        }

        private void btnSeletPath_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
            {
                string path = OpenFolderDialog(txtPath.Text);
                if (path.ToLower().StartsWith("c"))
                {
                    showMessageBoxError("لطفا مسیر ذخیره سازی را عوض نمایید ."
                        + "\n\n"
                        + "درایوی غیر از"
                        + "C" +
                        " را انتخاب نمایید", "خطا");
                    return;
                }
                txtPath.Text = path;
            }
            else
                txtPath.Text = OpenFolderDialog("d:\\");
        }
        List<View_Insurence_PersonalInfo> Taxlist = new List<View_Insurence_PersonalInfo>()
        {
            new View_Insurence_PersonalInfo()
            {
                DSW_EDATE="",
                DSW_MASH=184525252,
                DSW_SDATE="",
                JobName="مدیر پروژه",
                piFName="جواد",
                piInsurenceType=2,
                piLName="جوادی",
                piMeliCode="1234567985",
                piOneDaySalary=123434,
                ServiceLocation="تهران",
                startWorkDate=0,
            },
             new View_Insurence_PersonalInfo()
            {
                DSW_EDATE="",
                DSW_MASH=184525252,
                DSW_SDATE="",
                JobName="مدیر پروژه",
                piFName="مراد",
                piInsurenceType=2,
                piLName="مرادی",
                piMeliCode="1234413985",
                piOneDaySalary=123434,
                ServiceLocation="تهران",
                startWorkDate=0,
            }
        };

        private void btnCreateDick_Click(object sender, EventArgs e)
        {
            if (itbMonthDays.Value < 28)
            {
                frmSalTax.showMessageBoxError("لطفا تعداد روزهای ماه را درج نمایید", "خطا");
                return;
            }


            btnCreateDick.Text = "لطفا تا پایان عملیات منتظر بمانید...";
            btnCreateDick.Refresh();
            int DateNow = getDateNowINT();
            if (cmbPardakht.SelectedIndex == 0)
            {
                showMessageBoxError("لطفا نحوه پرداخت را مشخص نمایید", "خطا");
                btnCreateDick.Text = "ایجاد فایل";
                btnCreateDick.Refresh();
                return;
            }

            if (Taxlist == null || Taxlist.Count == 0)
            {
                showMessageBoxError("لطفا ابتدا لیست بیمه را ثبت نمایید", "خطا");
                btnCreateDick.Text = "ایجاد فایل";
                btnCreateDick.Refresh();
                return;
            }

            int TaxDate = int.Parse(ibYear.Value + "" + GetTowDigits(ibMonth.Value));
            string WK = CreateWKFile();//خلاصه وضعیت

            if (CreateWH_WP_Files())//اقلام حقوق و دستمزد// اطلاعات پرسنل
            {
                if (clsSalTax.CreateTextFile(txtPath.Text + "WK" + DateNow + TaxDate + ".txt", WK) && clsSalTax.CreateTextFile(txtPath.Text + "WP" + DateNow + TaxDate + ".txt", WP) && clsSalTax.CreateTextFile(txtPath.Text + "WH" + DateNow + TaxDate + ".txt", WH))
                    showMessageBoxSuccess(msgSuccess, "عملیات موفق");
            }
            else
                showMessageBoxError("عملیات ساخت فایل های حقوق و دستمزد و اطلاعات پرسنل با شکست مواجه شد", "خطا");
            btnCreateDick.Text = "ایجاد فایل";
            btnCreateDick.Refresh();
        }
        string WP = "", p = "", WH = "", h = "";
        public static string msgSuccess = "عملیات با موفقیت انجام شد.", msgError = "عملیات با شکست انجام شد." + "\n\n" + "لطفا دوباره اقدام نمایید.";
        public static void showMessageBoxError(string text, string title)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }
        public static bool showMessageBoxQuestion(string text, string title)
        {
            if (MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public static void showMessageBoxSuccess(string text, string title)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }
        public static int getDateNowINT()
        {
            return int.Parse(DateNow());
        }
        // دریافت تاریخ امروز 
        private static string DateNow()
        {
            System.Globalization.PersianCalendar perCalendar = new System.Globalization.PersianCalendar();
            DateTime dtMilad = new DateTime();
            dtMilad = DateTime.Now;
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
        /// <summary>
        /// باز کردن پنجره انتخاب مسیر
        /// </summary>
        /// <param name="startPath"></param>
        /// <returns></returns>
        public static string OpenFolderDialog(string startPath)
        {
            using (var fldrDlg = new FolderBrowserDialog())
            {
                fldrDlg.SelectedPath = startPath;
                fldrDlg.ShowNewFolderButton = true;
                fldrDlg.Tag = "انتخاب مسیر";
                fldrDlg.Description = "انتخاب مسیر ذخیره فایل ها";

                if (fldrDlg.ShowDialog() == DialogResult.OK)
                    return fldrDlg.SelectedPath;
            }
            return "";
        }
        private void ibYear_ValueChanged(object sender, EventArgs e)
        {
            itbSabtYear.Value = ibYear.Value;
            itbSabtMonth.Value = ibMonth.Value;
            itbSabtDay.Value = itbMonthDays.Value;
        }

        private bool CreateWH_WP_Files()
        {
            WP = ""; p = ""; WH = ""; h = "";
            try
            {
                foreach (var item in Taxlist)
                {
                    int isLastMonthWork = 0;// آیا ماه آخر کار این کارمند می باشد
                    if (item.DSW_EDATE != "")
                        isLastMonthWork = 1;

                    int isFirstMonthWork = 2;//نوع اطلاعات// آیا برای اولین بار تعریف می شود
                    if (item.DSW_SDATE != "")
                        isFirstMonthWork = 1;

                    h = item.piMeliCode + ","// کد ملی/ کد فراگیر
                         + cmbPardakht.SelectedIndex + ","// نوع پرداخت
                         + 1 + ","// تعداد ماه های کارکرد واقعی از ابتدای سال جاری
                         + isLastMonthWork + ","// آیا این ماه آخرین ماه فعالیت کاری حقوق بگیر می باشد؟
                         + 85 + ","// نوع ارز
                         + 1 + ","// نرخ تسعیر ارز
                         + item.startWorkDate + ","// تاریخ شروع به کار
                         + "" + ","// تاریخ پایان کار
                         + 1 + ","// وضعیت کارمند
                         + 1 + ","// وضعیت محل خدمت
                         + item.DSW_MASH + ","// ناخالص دریافتی
                         + 0 + ","// پرداخت
                         + 1 + ","//مسکن
                         + 0 + ","// مبلغ
                         + 1 + ","// پرداخت
                         + 0 + ","// هزینه
                         + 0 + ","// حق بیمه
                         + 0 + ","// تسهیلات
                         + 0 + ","// سایر
                         + 0 + ","// ناخالص
                         + 0 + ","// سایر پرداخ های
                         + 0 + ","// پاداش
                         + 0 + ","// پرداخت های غیر مستمر
                         + 0 + ","// کسر 
                         + 0 + ","// پرداخت مزایای
                         + 0 + ","// عیدی
                         + 0 + ","// بازخرید
                         + 0 + ","// کسر می شود: 
                         + 0 + ","
                         + 0 + ","
                         + 0 + ","
                         + 0 + ","//معافیت 
                         + 0 + ","// معافیت موضوع قانون
                         + 0 // مالیات متعلقه           
                         + (char)13 + (char)10;

                    WH += h;

                    // ساخت 
                    p = 1 + ","// نوع تابعیت
                            + isFirstMonthWork + ","//اگر برای اولین بار تعریف می شود 1 در غیر اینصورت 2
                            + item.piMeliCode + "," // کد ملی
                            + item.piFName + "," // نام
                            + item.piLName + "," // نام خانوادگی
                            + 103 + "," // کشور
                            + "" + "," // شناسه کارمند
                            + 1 + "," // مدرک تحصیلی
                            + item.JobName + "," // سمت
                            + item.piInsurenceType + "," // نوع بیمه
                            + "" + "," // نام بیمه
                            + "" + "," // شماره بیمه
                            + "" + "," // کد پستی محل سکونت
                            + "" + "," // نشانی محل سکونت
                            + item.startWorkDate + "," // تاریخ استخدام
                            + 1 + "," // نوع استخدام
                            + item.ServiceLocation + "," // محل خدمت
                            + 1 + "," // وضعیت محل خدمت
                            + 5 + "," // نوع قرارداد
                            + "" + "," // تاریخ پایان کار
                            + 1 + "," // وضعیت کارمند
                            + "" + "," // شماره تلفن همراه
                            + "" +// پست الکترونیک
                            +(char)13 + (char)10;
                    WP += p;
                }
                return true;
            }
            catch { return false; }
        }
        public static string GetTowDigits(int digit)
        {
            if (digit < 10)
                return "0" + digit;
            else
                return digit.ToString();
        }
        private string CreateWKFile()
        {
            return ibYear.Value + ","
                  + ibMonth.Text + ","
                  + Math.Round(itbBedehiMaliyati.Value, 0) + ","
                  + Math.Round(itbBedehiMaliyatiGhabli.Value, 0) + ","
                  + int.Parse(itbSabtYear.Text + GetTowDigits(itbSabtMonth.Value) + GetTowDigits(itbSabtDay.Value)) + ","
                  + /*cmbPardakht.SelectedIndex*/ 8 + ","//در صورت لزوم نحوه پرداخت را عوض نمایید
                  + txtCheckSerial.Text + ","
                  + int.Parse(itbCheckYear.Text + GetTowDigits(itbCheckMonth.Value) + GetTowDigits(itbCheckDay.Value)) + ","
                  + cmbBack.SelectedIndex + ","
                  + txtShobeh.Text + ","
                  + itbShomareHesab.Value + ","
                  + itbMablaghePardakhti.Value + ","
                  + int.Parse(itbTarikhPardakhtYear.Text + GetTowDigits(itbTarikhPardakhtMonth.Value) + GetTowDigits(itbTarikhPardakhtDay.Value)) + ","
                  + itbMablaghePardakhtiKhazaneh.Value;
        }
    }
}
