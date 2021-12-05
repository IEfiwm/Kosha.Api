using System.Collections.Generic;

namespace FishHoghoghi.Models
{
    public class ReportViewModel
    {
        public Setting Setting { get; set; }

        public List<string> Header { get; set; }

        public List<string> SubHeader { get; set; }

        public List<string> Footer { get; set; }

        public List<string> SubFooter { get; set; }

        public List<ReportColumn> Report { get; set; }

        public int limitYear { get; set; }

        public int limitMonth { get; set; }
    }
}