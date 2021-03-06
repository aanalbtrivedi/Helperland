using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class SPChngPasswordViewModel
    {
        [Key]
        public int UserId { get; set; }

        public string oldPassword { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password!")]
        [DataType(DataType.Password)]
        [Compare("oldPassword", ErrorMessage = "Confirm Password and Password must be the same")]
        public string ConfirmPassword { get; set; }
    }
}
