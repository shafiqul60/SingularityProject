using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Your UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }

    }
}
