using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetTailwind.Web.Models.Manage
{
    public class IndexViewModel
    {
        public string Username { get; set; } = null!;

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        public string StatusMessage { get; set; } = null!;
    }
}
