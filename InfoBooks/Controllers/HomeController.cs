using InfoBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoBooks.Data;
using InfoBooks.Models;

namespace InfoBooks.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository books = new EfBookRepository();
        IAuthorRepository authorRepository = new EfAuthourRepository();
        
        public ActionResult Index()
        {
            return View(books.Books);
        }  

        public PartialViewResult GetBooks()
        {
            return PartialView("GetBooks", books.Books);
        }

        public PartialViewResult GetBookInfo(int id)
        {
            Book book = books.GetBookById(id);
            
            return PartialView("GetBookInfo", book);
        }

        public PartialViewResult GetAuthors()
        {
            return PartialView("GetAuthors", authorRepository.Authors);
        }
        public PartialViewResult GetAuthorInfo(int id)
        {
            Author author = authorRepository.GetAuthourById(id);
            return PartialView("GetAuthorInfo", author);
        }
        public ActionResult Create()
        {
            PopulateAuthorsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    books.CreateBook(book);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("","Не получилось добавить книгу");
            }
            PopulateAuthorsDropDownList(book.AuthorId);
            return View(book);
        }

        public ActionResult CreateAthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAthor(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    authorRepository.CreateAuthor(author);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Не получилось добавить автора");
            }
            return View(author);
        }

        public ActionResult Edit(int id)
        {
            Book book = books.GetBookById(id);

            PopulateAuthorsDropDownList(book.Author.Id);
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                books.ChangeBook(book, book.Id);
                return RedirectToAction("Index");
            }
            PopulateAuthorsDropDownList(book.AuthorId);
            return View(book);
        }

        private void PopulateAuthorsDropDownList(object selectedAuthor = null)
        {
            var authorsQuery = from a in authorRepository.Authors
                               select a;
            ViewBag.AuthorId = new SelectList(authorsQuery, "Id", "AuthorName", selectedAuthor);
         }

        public ActionResult EditAuthor(int id)
        {
            Author author = authorRepository.GetAuthourById(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepository.ChangeAuthour(author.AuthorName, author.Id);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book book = books.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            books.DeleteBook(book);
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteAuthor(int id)
        {
            Book book = books.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult DeleteAuthor(Author author)
        {
            authorRepository.DeleteAuthor(author);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
