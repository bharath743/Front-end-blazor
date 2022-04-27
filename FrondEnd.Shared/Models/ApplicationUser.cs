using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrondEnd.Shared.Models
{
    public class ApplicationUser
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "The username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "PLease add a password"),
            DataType(DataType.Password), StringLength(6)]
        public string? Password { get; set; }
    }
}
