using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class RatingsViewModel
    {
        public int RatingId { get; set; }
        public int ServiceRequestId { get; set; }
        public int RatingTo { get; set; }
        public int RatingFrom { get; set; }
        public decimal Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime RatingData { get; set; }
        public decimal OnTimeArrival { get; set; }
        public decimal Friendly { get; set; }
        public decimal QualityOfService { get; set; }
    }
}
