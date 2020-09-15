using System.Linq;
using Classwork.Data;
using Classwork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Classwork.Controllers
{
    public class Book : Controller
    {
        private readonly ApplicationDbContext _context;
        public Book(ApplicationDbContext context)
        {
            _context = context;
        }// View All Bands
        public IActionResult Index()
        {
            return View(_context);
        }
        // View Book Details
        public IActionResult BookDetails(int bookID)
        {      
            BookModel matchingBand = _context.books.FirstOrDefault(book => book.id == bookID);
            if(matchingBand != null)
            {
                return View(matchingBand);
            } else 
            {
                return Content("No book found");
            }
        }
        // Add Book to DB
        [HttpPost]
        public IActionResult CreateBook(BookModel newBook)
        {
            if(ModelState.IsValid)
            {
                _context.books.Add(newBook);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            } else 
            {
                return Content("Invalid Model");
            }
        } 
        // Update Book in DB
        [HttpPost]
        public IActionResult UpdateBook(BookModel updateBook)
        {
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == updateBook.id);
            if(matchingBook != null)
            {
                if(ModelState.IsValid)
                {
                    matchingBook.title = updateBook.title;
                    matchingBook.author = updateBook.author;
                    matchingBook.isbn = updateBook.isbn;
                    matchingBook.isBestSeller = updateBook.isBestSeller;
                    _context.SaveChanges();
                    return RedirectToAction("Index");  
                } else 
                {
                    return Content("Invalid Model");
                }
            } else 
            {
                return Content("No book found");
            }
        } 
        // Delete Book from DB
        public IActionResult DeleteBook(int bookID)
        {
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            if(matchingBook != null)
            {
                _context.Remove(matchingBook);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else 
            {
                return Content("No book found");
            }
        } 
        // Display form to add Book
        [Authorize]
        public IActionResult CreateForm()
        {
            return View();
        } 
        // Display form to update Book
        [Authorize]
        public IActionResult UpdateForm(int bookID)
        {
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            if(matchingBook != null)
            {
                return View(matchingBook);
            } else 
            {
                return Content("No book found");
            }
        } 
        // Display page to delete Book
        [Authorize]
        public IActionResult DeleteConf(int bandID)
        {            
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bandID);
            if(matchingBook != null)
            {
                return View(matchingBook);
            } else 
            {
                return Content("No book found");
            }
        }
    }
}