using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
        public string ReturnURl { get; set; } = "/";
    }
}
