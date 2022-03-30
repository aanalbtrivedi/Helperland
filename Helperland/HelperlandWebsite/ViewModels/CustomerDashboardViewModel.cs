using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class CustomerDashboardViewModel
    {
        [Key]
        public int ServiceRequestId { get; set; }
        public DateTime StartingDate { get; set; }
        public double ServiceHours { get; set; }
        public decimal Payment { get; set; }
        public int? ServiceProviderId { get; set; }
        public int UserId { get; set; }
        public int dltSerReq { get; set; }
    }
}
