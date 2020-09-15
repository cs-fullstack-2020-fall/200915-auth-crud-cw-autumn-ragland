using System.Linq;
using Classwork.Data;
using Classwork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Classwork.Controllers
{
    public class Book : Controller
    {
        // ref to db context
        private readonly ApplicationDbContext _context;
        public Book(ApplicationDbContext context)
        {
            _context = context;
        }
        // View All Bands
        public IActionResult Index()
        {
            return View(_context);
        }
        // View Book Details
        public IActionResult BookDetails(int bookID)
        {      
            // find book in db by id
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            // if book is found
            if(matchingBook != null)
            {
                return View(matchingBook);
            } else 
            // if book is not found
            {
                return Content("No book found");
            }
        }
        // Add Book to DB
        [HttpPost]
        public IActionResult CreateBook(BookModel newBook)
        {
            // if data passed meets model validation
            if(ModelState.IsValid)
            {
                // add to db
                _context.books.Add(newBook);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            } else 
            {
                return View("CreateForm", newBook);
            }
        } 
        // Update Book in DB
        [HttpPost]
        public IActionResult UpdateBook(BookModel updateBook)
        {
            // find book by id
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == updateBook.id);
            if(matchingBook != null)
            {   
                // if data passed meets model validation
                if(ModelState.IsValid)
                {
                    // update found book with data passed
                    matchingBook.title = updateBook.title;
                    matchingBook.author = updateBook.author;
                    matchingBook.isbn = updateBook.isbn;
                    matchingBook.isBestSeller = updateBook.isBestSeller;
                    _context.SaveChanges();
                    return RedirectToAction("Index");  
                } else 
                // render form again populated with invalid data
                {
                    return View("UpdateForm", updateBook);
                }
            } else 
            {
                return Content("No book found");
            }
        } 
        // Delete Book from DB
        public IActionResult DeleteBook(int bookID)
        {
            // find book in db by id
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            // if book is found
            if(matchingBook != null)
            {
                // remove from db
                _context.Remove(matchingBook);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else 
            {
                return Content("No book found");
            }
        } 
        // Display form to add Book - Must be logged in to access
        [Authorize]
        public IActionResult CreateForm()
        {
            return View();
        } 
        // Display form to update Book - Must be logged in to access
        [Authorize]
        public IActionResult UpdateForm(int bookID)
        {
            // find book in db by id
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            // if book is found
            if(matchingBook != null)
            {
                return View(matchingBook);
            } else 
            {
                return Content("No book found");
            }
        } 
        // Display page to delete Book - Must be logged in to access
        [Authorize]
        public IActionResult DeleteConf(int bookID)
        {            
            // find book by id
            BookModel matchingBook = _context.books.FirstOrDefault(book => book.id == bookID);
            // if book is found
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