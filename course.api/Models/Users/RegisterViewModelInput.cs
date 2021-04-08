using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Models
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage = "Your name is Required!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Your last name is Required!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Your e-mail is Required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your room is Required!")]
        public string Room { get; set; }

        [Required(ErrorMessage = "Your login is Required!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Your password is Required!")]
        public string Password { get; set; }
    }
}
