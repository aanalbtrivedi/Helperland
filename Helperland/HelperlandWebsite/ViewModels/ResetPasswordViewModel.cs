using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Please enter confirm password!")]
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "Confirm Password and Password must be the same")]
        public string confirmPassword { get; set; }
    }
}
