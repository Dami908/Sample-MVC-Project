using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class EFCartRepository:ICartRepository
    {
        private AppDbContext dbContext;

        public EFCartRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public void AddBook(CartItem book)
        {
            
            dbContext.Carts.Add(book);
            dbContext.SaveChanges();
        }

   

        public void DeleteBook(int bookId)
        {
            CartItem book = getCart().FirstOrDefault(b => b.cartItemId== bookId);
            //--bookId;
            dbContext.Carts.Remove(book);
            dbContext.SaveChanges();
        }
        public IQueryable<CartItem> getCart()
        {
            return dbContext.Carts;
        }

        public IQueryable<Book> getCarts()
        {
            throw new NotImplementedException();
        }
    }
}
