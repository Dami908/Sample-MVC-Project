using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class CartItem
    {
        [Key]
        public int cartItemId { get; set; }
        public int bookId { get; set; }
        public int ISBN { get; set; }
        public string AuthorName { get; set; }
        public string BookTitle { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
        
    }
}
