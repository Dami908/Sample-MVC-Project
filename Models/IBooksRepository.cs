using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> getBooks();
        void AddBook(Book book);
        void EditBook(Book book);
        void AddReview(Book book);
        void DeleteBook(int bookId);
        Book getBook(int bookId);
    }
}
