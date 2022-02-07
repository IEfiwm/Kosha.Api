using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Common.Model
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string AccountNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public bool Status { get; set; }
    }
}
