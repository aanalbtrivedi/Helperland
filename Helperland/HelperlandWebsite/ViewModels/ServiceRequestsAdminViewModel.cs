using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class ServiceRequestsAdminViewModel
    {
        [Key]
        public int ServiceId { get; set; }
        public DateTime StartingDate { get; set; }
        public double Hours { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? Discount { get; set; }
        public int Status { get; set; }

    }
}
