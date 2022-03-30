using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class UpcomingServiceViewModel
    {
        [Key]
        public int ServiceRequestId { get; set; }
        public int chkCancel { get; set; }
        public int chkCompleted { get; set; }
        public DateTime StartingDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double ServiceHours { get; set; }
        public decimal Payment { get; set; }
    }
}
