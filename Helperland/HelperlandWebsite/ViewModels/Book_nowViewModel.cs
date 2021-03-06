using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class Book_nowViewModel
    {
        public int userId { get; set; }
        [Required(ErrorMessage = "Please enter Postal Code", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string PostalCode { get; set; }
        public DateTime Cleandate { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public float Startingtime { get; set; }
        public double Hours { get; set; }
        public double ExtraHours { get; set; }
        public decimal SubTotal { get; set; }
        public int Extraservice { get; set; }
        public string Comments { get; set; }
        public int Pets { get; set; }
        public string promocode { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal ServiceHourlyRate { get; set; }
        public decimal Discount { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string PostalCodeUser { get; set; }
        public int AddressID { get; set; }
        public int ServiceId { get; set; }
        public int Status { get; set; }
        public string ExtraServ { get; set; }


    }
}
