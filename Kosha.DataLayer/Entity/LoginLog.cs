using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kosha.DataLayer
{
    public partial class LoginLog
    {
        public string UserName { get; set; }
        public string LoginAt { get; set; }
        public string MacAddress { get; set; }
    }
}
