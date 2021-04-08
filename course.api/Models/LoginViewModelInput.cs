using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Models
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Your Login is Required!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Your Password is Required!")]
        public string Password { get; set; }
    }
}
