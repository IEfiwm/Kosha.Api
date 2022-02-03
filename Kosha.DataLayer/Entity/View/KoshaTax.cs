using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kosha.DataLayer
{
    public partial class KoshaTax
    {
        public string نام { get; set; }
        public string نامخانوادگی { get; set; }
        public string کدپرسنلی { get; set; }
        public string کدملی { get; set; }
        public string ملیت { get; set; }
        public string جمعمزایا { get; set; }
        public string مزایایمشمول { get; set; }
        public string ماليات { get; set; }
        public string مستمرحقوقپایهبنومسکنوحقاولاد { get; set; }
        public string مستمرحقوقپایهوپایهسنوات { get; set; }
        public string غیرمستمرمشمولوغیرمشمول { get; set; }
        public string غیرمستمرمشمول { get; set; }
        public long? ProjectRef { get; set; }
        public string ماه { get; set; }
        public string سال { get; set; }
    }
}
