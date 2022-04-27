using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrondEnd.Shared.DTOs
{
#nullable disable
    public class UserDTO
    {
        [Required(ErrorMessage = "Must specify user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirme the password")]
        //[Compare("Password", ErrorMessage = "The password does not match")]
        //public string ConfPassword { get; set; }
    }
}
