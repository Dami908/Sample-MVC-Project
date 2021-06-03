using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        [Required(ErrorMessage="Please enter a ISBN Number" )]
        public int ISBN { get; set; }
        [Required(ErrorMessage = "Please enter a Firstname")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Please enter a Lastname")]
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "Please enter an Amount")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Please enter a desired quantity")]
        public int Quantity { get; set; }
        public string Review { get; set; }

    }
}
