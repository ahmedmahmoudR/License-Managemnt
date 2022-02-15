using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace License_Managemnt.Models
{
    public class LicenseModel
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string LicenseKey { get; set; }
       
    }
}