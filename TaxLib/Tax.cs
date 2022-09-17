using System;
using System.Collections.Generic;
using TaxLib.Base;
using TaxLib.Base.Model;

namespace TaxLib
{
    public class Tax
    {
        public string Path { get; set; }

        public Message GenerateWK(MKModel model)
        {
            var response = new Message();

            if (model is null)
            {
                response.Body = "اطلاعات ارسال شده خالی می باشد.";

                response.Type = MessageType.Error;

                return response;
            }

            if (model.PaymentMethod == 0)
            {
                response.Body = "نوع پرداخت مشخص نشده است.";

                response.Type = MessageType.Error;

                return response;
            }

            string wk = Utility.CreateWK(model);

            Utility.CreateTextFile(Path + "WK" + model.Year + model.Month + ".txt", wk);

            response.FilePath = Path + "WK" + model.Year + model.Month + ".txt";

            response.Body = $@"فایل در مسیر {Path} ساخته شد.";

            return response;
        }

        public Message GenerateWP(int year, int month, List<PersonnelInfo> personnels)
        {
            var response = new Message();

            if (year == 0 || month == 0 || personnels is null)
            {
                response.Body = "اطلاعات ارسال شده خالی می باشد.";

                response.Type = MessageType.Error;

                return response;
            }

            string p = "";

            foreach (var item in personnels)
            {
                p += 1 + ","// نوع تابعیت
                + item.FirstMonthWork + ","//اگر برای اولین بار تعریف می شود 1 در غیر اینصورت 2
                + item.NationalCode + "," // کد ملی
                + item.Name + "," // نام
                + item.LastName + "," // نام خانوادگی
                + 103 + "," // کشور
                + "" + "," // شناسه کارمند
                + 1 + "," // مدرک تحصیلی
                + item.JobTitle + "," // سمت
                + item.InsurenceType + "," // نوع بیمه
                + "" + "," // نام بیمه
                + "" + "," // شماره بیمه
                + "" + "," // کد پستی محل سکونت
                + "" + "," // نشانی محل سکونت
                + item.StartWorkDate + "," // تاریخ استخدام
                + 1 + "," // نوع استخدام
                + item.ServiceLocation + "," // محل خدمت
                + 1 + "," // وضعیت محل خدمت
                + 5 + "," // نوع قرارداد
                + "" + "," // تاریخ پایان کار
                + 1 + "," // وضعیت کارمند
                + "" + "," // شماره تلفن همراه
                + "" +// پست الکترونیک
                +(char)13 + (char)10;
            }

            Utility.CreateTextFile(Path + "WP" + year + month + ".txt", p);

            response.FilePath = Path + "WP" + year + month + ".txt";

            response.Body = $@"فایل در مسیر {Path} ساخته شد.";

            return response;
        }

        public Message GenerateWH(int year, int month, int paymentMethod, List<PersonnelInfo> personnels)
        {
            var response = new Message();

            if (year == 0 || month == 0 || personnels is null)
            {
                response.Body = "اطلاعات ارسال شده خالی می باشد.";

                response.Type = MessageType.Error;

                return response;
            }

            string h = "";

            foreach (var item in personnels)
            {
                h += item.NationalCode + ","// کد ملی/ کد فراگیر
                + paymentMethod + ","// نوع پرداخت
                + 1 + ","// تعداد ماه های کارکرد واقعی از ابتدای سال جاری
                + item.EndMonthWork + ","// آیا این ماه آخرین ماه فعالیت کاری حقوق بگیر می باشد؟
                + 85 + ","// نوع ارز
                + 1 + ","// نرخ تسعیر ارز
                + item.StartWorkDate + ","// تاریخ شروع به کار
                + "" + ","// تاریخ پایان کار
                + 1 + ","// وضعیت کارمند
                + 1 + ","// وضعیت محل خدمت
                + item.IncludedBenefits + ","// ناخالص دریافتی
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
            }

            Utility.CreateTextFile(Path + "WH" + year + month + ".txt", h);

            response.FilePath = Path + "WH" + year + month + ".txt";

            response.Body = $@"فایل در مسیر {Path} ساخته شد.";

            return response;
        }
    }
}
