using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class UserManagementViewModel
    {
        [Key]
       // public int UserId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserTypeId { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
    }
}
