using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class SPMySettingsViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailaddress { get; set; }
        public string MobileNumber { get; set; }
        public int LanguageId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Streetname { get; set; }
        public int? NationalityId { get; set; }
        public int Gender { get; set; }
        public int chkPassword { get; set; }
        public string UserProfilePicture { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

    }
}
