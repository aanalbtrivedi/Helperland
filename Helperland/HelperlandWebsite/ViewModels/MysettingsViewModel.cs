using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class MysettingsViewModel
    {
        [Key]

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailaddress { get; set; }
        public string MobileNumber { get; set; }
        public int LanguageId { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
