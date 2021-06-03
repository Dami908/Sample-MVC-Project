using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public interface ICartRepository
    {
        IQueryable<CartItem> getCart();
        void AddBook(CartItem book);
       // void EditBook(Book book);
       // void AddReview(Book book);
        void DeleteBook(int bookId);
        //Book getCart(int bookId);
    }
}
