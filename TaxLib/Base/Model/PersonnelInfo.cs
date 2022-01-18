namespace TaxLib.Base.Model
{
    public class PersonnelInfo
    {
        public string StartWorkingDate { get; set; }// تاریخ شروع به کار

        public int FirstMonthWork { get; set; } // اگر ماه اول است 1 در غیر این صورت 2

        public int EndMonthWork { get; set; } // اگر ماه اخر است 1 در غیر این صورت 2

        public string EndWorkingDate { get; set; }// تاریخ ترک کار

        public int EndWorkDate { get; set; }// تاریخ ترک کار

        public int IncludedBenefits { get; set; }// جمع دستمزد و مزایای ماهانه مشمول  ) ناخالص دریافتی)

        public string NationalCode { get; set; }// کد ملی

        public string Name { get; set; }// نام

        public string LastName { get; set; } // نام خانوادگی

        public int OneDaySalary { get; set; }// حقوق یک روز; }

        public int InsurenceType { get; set; } // نوع بیمه

        public int StartWorkDate { get; set; } // تاریخ شروع به کار

        public string JobTitle { get; set; }//نام شغل

        public string ServiceLocation { get; set; } // شهر محل خدمت
    }
}
