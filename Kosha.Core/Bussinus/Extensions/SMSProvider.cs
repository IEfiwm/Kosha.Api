﻿using SmsIrRestful;
using System.Collections.Generic;
using Kosha.Core.Bussinus.Providers;

namespace Kosha.Core.Bussinus.Extensions
{
    public static class SMSProvider
    {
        public static bool SendOTPCode(string recipient, string code)
        {
            bool result = false;

            var parameters = new List<UltraFastParameters>();

            parameters.Add(new UltraFastParameters
            {
                Parameter = "Code",
                ParameterValue = code
            });

            result= SMSIRProvider.SendMessage(recipient, 61243, parameters);

            //var message = PublicSettings.OTPTemplate.Replace("#CODE#", code);

            //var client = new RestClient($@"https://smspanel.trez.ir/SendMessageWithCode.ashx?Username=iefiwm&Password=235421402246&Mobile={recipient}&Message={message}");

            //client.Timeout = -1;

            //var request = new RestRequest(Method.GET);

            //IRestResponse response = client.Execute(request);

            //if (Convert.ToInt32(response.Content.ToString()) != 8) result = true;

            return result;
        }
    }
}
