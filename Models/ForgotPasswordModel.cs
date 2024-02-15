using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StudentManagement.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}