using BookCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // as we will be working with Lists<Book>

namespace BookCatalog.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();

        //here Every action method will return a view with the model
        public IActionResult Index()
        {
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count + 1; // Simple ID generation
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book); //returning the same view with validation errors
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = books.Find(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.Genre = book.Genre;
                    existingBook.PublishedDate = book.PublishedDate;
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}