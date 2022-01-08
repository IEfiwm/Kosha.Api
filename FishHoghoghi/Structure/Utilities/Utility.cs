using Elmah;
using FishHoghoghi.Models;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;

namespace FishHoghoghi.Utilities
{
    public static class Utility
    {
        public static string ToPersianNumber(this string englishNumber)
        {
            if (!string.IsNullOrWhiteSpace(englishNumber))
            {
                string[] strArray = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
                for (int i = 0; i < 10; i++)
                {
                    englishNumber = englishNumber.Replace(i.ToString(), strArray[i]);
                }
            }
            return englishNumber;
        }

        public static string ToPersianNumber(this decimal number)
        {
            return number.ToString().ToPersianNumber();
        }

        public static string ToPersianNumber(this int number)
        {
            return number.ToString().ToPersianNumber();
        }

        public static string ToPersianHourNumber(this decimal number)
        {
            var number2 = Convert.ToInt64(number);

            return number2.ToPersianHourNumber();
        }

        public static string ToPersianHourNumber(this long num)
        {
            var num4 = num / 60;

            var num4_1 = num % 60;

            return (num4 + ":" + num4_1).ToPersianNumber();
        }

        public static void SetCurrencyInfo(this NumberFormatInfo provider, int decimalDigits, string decimalSeparator, string groupSeparator, string symbol)
        {
            provider.CurrencyDecimalDigits = decimalDigits;

            provider.CurrencyDecimalSeparator = decimalSeparator;

            provider.CurrencyGroupSeparator = groupSeparator;

            provider.CurrencySymbol = symbol;
        }

        public static string GetIPAddress()
        {
            HttpContext current = HttpContext.Current;

            string str = current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(str))
            {
                char[] separator = new char[] { ',' };

                string[] strArray = str.Split(separator);

                if (strArray.Length != 0)
                {
                    return strArray[0];
                }
            }

            return current.Request.ServerVariables["REMOTE_ADDR"];
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

        public static HttpResponseMessage SetErrorResponse(HttpStatusCode status, string message)
        {
            return new HttpResponseMessage(status)
            {
                Content = new StringContent(SerializeToJson(new BaseResponse() { message = message }))
            };
        }

        public static HttpResponseMessage SetBadResponse()
        {
            return SetErrorResponse(HttpStatusCode.BadRequest, "متاسفانه درخواست معتبر نیست.");
        }

        public static HttpResponseMessage SetIntervalErrorResponse()
        {
            return SetErrorResponse(HttpStatusCode.InternalServerError, "متاسفانه خطایی رخ داده.");
        }

        public static HttpResponseMessage Response(object model, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new HttpResponseMessage(status)
            {
                Content = new StringContent(model.SerializeJson())
            };
        }

        public static void Log(string message)
        {
            ErrorLog.GetDefault(null).Log(new Error(new Exception(message)));
        }

        public static void Log(Exception exception)
        {
            ErrorLog.GetDefault(null).Log(new Error(exception));
        }

        public static string GetHostName(this HttpRequestMessage Request)
        {
            return Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority;
        }

        public static bool CreateDirectory(string filePath)
        {
            if (!File.Exists(filePath))
                System.IO.Directory.CreateDirectory(filePath);

            return true;
        }

        public static string GetContractTemplateName(long projectId)
        {
            //var items = JsonConvert.DeserializeObject<object>(CommonHelper.ReadJson("Jsons", "ContractTemplate.json"));

            if (projectId == 2118)
            {
                return "template-2118.docx";
            }

            return "template-other.docx";
        }
    }
}