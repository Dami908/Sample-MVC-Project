using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Microsoft.AspNetCore.Authorization;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private IBooksRepository bookrepo;
        private ICartRepository CartRepo;

        public HomeController(IBooksRepository booksRepository, ICartRepository cartRepository)
        {
            bookrepo = booksRepository;
            CartRepo = cartRepository;
        }

        
        public IActionResult DataPage()
        { 
            return View(bookrepo.getBooks());
        }
        public ViewResult Change1()
        {
            ViewBag.Layout = "_Layout";
            return View("SettingsPage");
        }
        public ViewResult Change2()
        {
            ViewBag.Layout = "_Layout_second";
            return View("SettingsPage", "Index");
        }
        public IActionResult SettingsPage()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserPage()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Insert()
        {
            return View(new Book());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert(Book obj)
        {
            //FakeRepository.AddNewStudent(obj);
            bookrepo.AddBook(obj);
            return View("ItemsList", bookrepo.getBooks());
        }
        public IActionResult ItemsList()
        {
            return View(bookrepo.getBooks());
        }
        public IActionResult checkOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Message()
        {
            return View();
        }
        public IActionResult CartTRoller()
        {
            return View(CartRepo.getCart());
        }


        public IActionResult DisplayPage(int bookId)
        {
            return View("DisplayPage", bookrepo.getBook(bookId));
        }
        public IActionResult Cart(int bookId)
        {
            // get the book from bookrepo.
            Book bookTemp = bookrepo.getBook(bookId);
            CartItem cartItem = new CartItem();

            cartItem.bookId = bookTemp.bookId;
            cartItem.BookTitle = bookTemp.BookTitle;
            cartItem.AuthorName = bookTemp.AuthorName;
            cartItem.Amount = bookTemp.Amount;
            cartItem.Quantity = bookTemp.Quantity;
            cartItem.ISBN = bookTemp.ISBN;

            //Access IBookCartRepository, then add a new book 
             CartRepo.AddBook(cartItem);
            bookrepo.DeleteBook(bookId);

            return View("Cart", CartRepo.getCart());
        }
        public IActionResult DeleteCart(int bookId)
        {
            CartRepo.DeleteBook(bookId);
            return View("Cart", CartRepo.getCart());
        }
        [Authorize]
        public IActionResult Delete(int bookId)
        {
            bookrepo.DeleteBook(bookId);
            return View("ItemsList", bookrepo.getBooks());
        }
        
        [HttpGet]
        [Authorize]
        public ViewResult EditPage(int bookId)
        {
            return View(bookrepo.getBooks().FirstOrDefault(b => b.bookId == bookId));
        }
        [HttpGet]
        public ViewResult UserPage(int bookId)
        {
            Book reviewBook = bookrepo.getBooks().FirstOrDefault(b => b.bookId == bookId);
            return View(reviewBook);
        }

        [HttpPost]
        public IActionResult AddReviews(Book books)
        {
            if (ModelState.IsValid)
            {
                bookrepo.EditBook(books);
                TempData["message"] = $"{books.ISBN}has been saved";
                return RedirectToAction("ItemsList");
            }
            else
            {
                return View("DisplayPage",books);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Book books)
        {
            if (ModelState.IsValid)
            {
                bookrepo.EditBook(books);
                TempData["message"] = $"{books.ISBN}has been saved";
                return RedirectToAction("ItemsList");
            }
            else
            {
                return View(books);
            }
        }
    }
}
