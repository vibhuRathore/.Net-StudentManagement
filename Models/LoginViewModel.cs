using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}