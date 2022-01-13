using System;
using System.Collections.Generic;
using TaxLib.Base;
using TaxLib.Base.Model;

namespace TaxLib
{
    public class Tax
    {
        public string Path { get; set; }

        public List<PersonnelInfo> Personnels { get; set; }

        public Message GenerateWK(MKModel model)
        {
            var response = new Message();

            if (model.PaymentMethod == 0)
            {
                response.Body = "نوع پرداخت مشخص نشده است.";

                response.Type = MessageType.Error;

                return response;
            }

            string wk = Utility.CreateWK(model);

            Utility.CreateTextFile(Path + "WK" + model.Year + model.Month + ".txt", wk);

            response.Body = $@"فایل در مسیر {Path} ساخته شد.";

            return response;
        }

        public Message GenerateWP()
        {
            var response = new Message();

            return response;
        }

        public Message GenerateWH()
        {
            var response = new Message();

            return response;
        }
    }
}
