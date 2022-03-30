using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class CustomerHistoryViewModel
    {
        [Key]
        public int ServiceRequestId { get; set; }
        public DateTime StartingDate { get; set; }
        public double ServiceHours { get; set; }
        public decimal Payment { get; set; }
        public int? ServiceProviderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Status { get; set; }
        public int RatingId { get; set; }
        //public int ServiceRequestId { get; set; }
        public int? RatingTo { get; set; }
        public int RatingFrom { get; set; }
        public decimal Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime RatingDate { get; set; }
        public decimal OnTimeArrival { get; set; }
        public decimal Friendly { get; set; }
        public decimal QualityOfService { get; set; }
    }
}
