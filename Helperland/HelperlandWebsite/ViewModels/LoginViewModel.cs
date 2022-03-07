using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;


namespace HelperlandWebsite.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage ="Please Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
