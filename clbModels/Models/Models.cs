using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clbModels
{
    // پارامتر های کارخانه
    public partial class SalInsurenceDiskFactory
    {
        public int insAutoID { get; set; }// شماره ردیف
        public string DSK_ID { get; set; }// کد کارگاه
        public string DSK_NAME { get; set; }//نام کارگاه
        public string DSK_FARM { get; set; }// نام کارفرما
        public string DSK_ADRS { get; set; }//آدرس کارگاه 
        public int DSK_KIND { get; set; }//نوع لیست
        public int DSK_YY { get; set; }//سال عملکرد
        public int DSK_MM { get; set; }// ماه عملکرد
        public string DSK_LISTNO { get; set; }// شماره لیست معمولا همان ماه درج می شود
        public string DSK_DISC { get; set; }// شرح لیست
        public int DSK_NUM { get; set; }// تعداد کارکنان
        public int DSK_TDD { get; set; }// مجموع روزهای کارکرد
        public long DSK_TROOZ { get; set; }//مجموع دستمزد روزانه
        public long DSK_TMAH { get; set; }//مجموع دستمزد ماهانه
        public long DSK_TMAZ { get; set; }// مجموع مزایای ماهانه مشمول
        public long DSK_TMASH { get; set; }//مجموع دستمزد و مزایای ماهانه مشمول
        public long DSK_TTOTL { get; set; }// مجموع کل دستمزد و مزایای ماهانه ( مشمول و غیر مشمول)
        public long DSK_TBIME { get; set; }// مجموع حق بیمه سهم بیمه شده
        public long DSK_TKOSO { get; set; }//مجموع حق بیمه سهم کارفرما
        public long DSK_BIC { get; set; }// مجموع حق بیمه بیکاری
        public int DSK_RATE { get; set; }//نرخ حق بیمه
        public int DSK_PRATE { get; set; }// نرخ پورسانتاژ
        public long DSK_BIMH { get; set; }// نرخ مشاغل سخت و زیان آور
        public string MON_PYM { get; set; }// ردیف پیمان
    }

    // پارامتر های کارمندان
    public partial class SalInsurenceDiskPersonal
    {
        public int insAutoID { get; set; }//شماره ردیف
        public string piPersonalID { get; set; }// شماره پرسنلی کارمند
        public string DSW_ID { get; set; }//کد کارگاه
        public int DSW_YY { get; set; }// سال - باید 4 رقمی باشد
        public int DSW_MM { get; set; }// ماه
        public string DSW_LISTNO { get; set; }// شماره لیست : معمولا همان ماه در آن درج می شود
        public string DSW_ID1 { get; set; }// شماره بیمه کارمند
        public string DSW_FNAME { get; set; }// نام
        public string DSW_LNAME { get; set; }// نام خانوادگی
        public string DSW_DNAME { get; set; }// نام پدر
        public string DSW_IDNO { get; set; }//شماره شناسنامه
        public string DSW_IDPLC { get; set; }// محل صدور
        public string DSW_IDATE { get; set; }// تاریخ صدور
        public string DSW_BDATE { get; set; }//تاریخ تولد
        public string DSW_SEX { get; set; }// جنسیت
        public string DSW_NAT { get; set; }// ملیت
        public string DSW_OCP { get; set; }// شرح شغل
        public string DSW_SDATE { get; set; }// تاریخ شروع به کار
        public string DSW_EDATE { get; set; }// تاریخ ترک کار
        public int DSW_DD { get; set; }// تعداد روزهای کارکرد
        public long DSW_ROOZ { get; set; }// دستمزد روزانه
        public long DSW_MAH { get; set; }// دستمزد ماهانه
        public long DSW_MAZ { get; set; }//مزایای ماهانه
        public long DSW_MASH { get; set; }// جمع دستمزد و مزایای ماهانه مشمول
        public long DSW_TOTL { get; set; }// جمع کل دستمزد و مزایای ماهانه
        public long DSW_BIME { get; set; }// حق بیمه سهم کارمند
        public int DSW_PRATE { get; set; }// نرخ پورسانت
        public string DSW_JOB { get; set; }// کد شغل
        public string PER_NATCOD { get; set; }// کد ملی        
    }

}
