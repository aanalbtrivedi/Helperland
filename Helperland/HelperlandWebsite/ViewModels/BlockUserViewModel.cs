using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.ViewModels
{
    public class BlockUserViewModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TargetUserId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsBlocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
