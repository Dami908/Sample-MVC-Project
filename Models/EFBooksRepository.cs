using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Sample.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private AppDbContext dbContext;

        public EFBooksRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public void AddBook(Book book)
        {
            EditBook(book);
            AddReview(book);
            //dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
        public void AddReview(Book book)
        {
            if (book.bookId == 0)
            {
                dbContext.Books.Add(book);
            }
            else
            {
                Book dbEntry=dbContext.Books.
                FirstOrDefault(p => p.bookId == book.bookId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorName = book.AuthorName;
                    dbEntry.BookTitle = book.BookTitle;
                    dbEntry.ISBN = book.ISBN;
                    dbEntry.Amount = book.Amount;
                    dbEntry.Review = book.Review;
                }

            }
            dbContext.SaveChanges();

        }

        public void DeleteBook(int bookId)
        {
            Book book = getBooks().FirstOrDefault(b => b.bookId == bookId);
            --bookId;
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public void EditBook(Book book)
        {
            if (book.bookId == 0)
            {
                dbContext.Books.Add(book);
            }
            else
            {
                Book dbEntry = dbContext.Books
                .FirstOrDefault(p => p.bookId == book.bookId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorName = book.AuthorName;
                    dbEntry.BookTitle = book.BookTitle;
                    dbEntry.ISBN = book.ISBN;
                    dbEntry.Amount = book.Amount;
                    dbEntry.Review = book.Review;

                }
            }
            dbContext.SaveChanges();

        }

        public IQueryable<Book> getBooks()
        {
            return dbContext.Books;
        }

        public Book getBook(int bookId)
        {
            Book bookTemp = getBooks().FirstOrDefault(b => b.bookId == bookId);
            return bookTemp;
            
        }
    }
}
