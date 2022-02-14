using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Common.Helper
{
    public static class CoreCommonHelper
    {
        private static string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public static string GenerateRandomOTP(int iOTPLength)
        {
            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;
            }

            return sOTP;
        }

        public static string GetTowDigits(int digit)
        {
            if (digit < 10)
                return "0" + digit;
            else
                return digit.ToString();
        }

        public static HttpResponseMessage SetErrorResponse(HttpStatusCode status, string message)
        {
            return new HttpResponseMessage(status)
            {
                Content = new StringContent(SerializeToJson(new BaseResponse() { message = message }))
            };
        }

        public static string SerializeToJson(object obj, bool enableCamelCase = true)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            if (enableCamelCase)
            {
                return JsonConvert.SerializeObject(obj,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }

            return JsonConvert.SerializeObject(obj);
        }

        public static HttpResponseMessage SetBadResponse()
        {
            return SetErrorResponse(HttpStatusCode.BadRequest, "متاسفانه درخواست معتبر نیست.");
        }

        public static HttpResponseMessage SetIntervalErrorResponse()
        {
            return SetErrorResponse(HttpStatusCode.InternalServerError, "متاسفانه خطایی رخ داده.");
        }

        public class BaseResponse
        {
            public string message { get; set; }
        }
    }
}
