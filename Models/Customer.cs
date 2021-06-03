using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter your firstname")]
        public string firstname;
        [Required(ErrorMessage = "Please enter your Lastname")]
        public string lastname;
        [Required(ErrorMessage = "Please enter your Address")]
        public string Address;
        [Required(ErrorMessage = "Please enter your city")]
        public string city;
        [Required(ErrorMessage = "Please enter your state")]
        public string state;
    }
}
