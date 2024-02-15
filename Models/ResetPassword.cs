using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class ResetPassword
    {
        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [StringLength(100, ErrorMessage = "The Password must be at least 8 characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage ="Please Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}