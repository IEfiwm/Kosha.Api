using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Common.Const
{
    public static class PublicSettings
    {
        public const byte OTPExpireDate = 3; // 3 minute

        public const byte OTPCodeLenght = 5; // 3 minute

        public const string OTPTemplate = "Code: #CODE#";

        public static double TokenExpireDate = 2;// 2 hour
    }
}
