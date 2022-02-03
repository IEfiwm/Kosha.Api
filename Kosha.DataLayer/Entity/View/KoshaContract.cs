using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kosha.DataLayer
{
    public partial class KoshaContract
    {
        public string نام { get; set; }
        public string نامخانوادگی { get; set; }
        public string نامپدر { get; set; }
        public DateTime? تاریختولد { get; set; }
        public string کدپستی { get; set; }
        public string کدشغل { get; set; }
        public string عنوانشغل { get; set; }
        public string محلتولد { get; set; }
        public byte تعداداولاد { get; set; }
        public string مدرکتحصیلی { get; set; }
        public string آدرس { get; set; }
        public int مزدماهانه { get; set; }
        public int مزدروزانه { get; set; }
        public int پایهسنواتروزانه { get; set; }
        public int پایهسنواتماهانه { get; set; }
        public string وضعیتسربازی { get; set; }
        public string وضعیتتاهل { get; set; }
        public string جنسیت { get; set; }
        public string کدملی { get; set; }
        public string کدپرسنلی { get; set; }
        public string شمارهشناسنامه { get; set; }
        public long? ProjectRef { get; set; }
        public int بنکارگری { get; set; }
        public int حقمسکن { get; set; }
        public int حقاولاد { get; set; }
        public int? جمعکلمزایا { get; set; }
        public int? جمعمزدمبناروزانه { get; set; }
        public int? جمعمزدمبناماهانه { get; set; }
        public int? جمعکلمزدومزایا { get; set; }
        public string نامپروژه { get; set; }
    }
}
