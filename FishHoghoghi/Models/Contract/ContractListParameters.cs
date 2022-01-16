using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishHoghoghi.Models.Contract
{
    public class ContractListParameters
    {
        public List<string> usernameList { get; set; }
        public long projectId { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
    }
}