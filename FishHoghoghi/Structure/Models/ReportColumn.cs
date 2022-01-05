using FishHoghoghi.Business.Models;
using System.Collections.Generic;

namespace FishHoghoghi.Models
{
    public class ReportColumn
    {
        public string Title { get; set; }

        public List<SummaryFieldInfo> Contents { get; set; }

    }
}