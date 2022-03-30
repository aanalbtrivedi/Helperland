using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class ListAddressViewModel
    {
        public int AddressId { get; set; }
        public int chkforDelete { get; set; }
        public int chkforUpdate { get; set; }
        public int chkforAdd { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string PostalCodeUser { get; set; }
    }
}
