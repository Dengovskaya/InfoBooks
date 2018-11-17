using InfoBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoBooks.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository<BookModels> db = new BookRepository();
        
        public ActionResult Index()
        {
            ViewBag.Books = db.GetBookList();
            return View(db.GetBookList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookModels book)
        {
            if (ModelState.IsValid)
            {
                db.Create(book);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            BookModels book = db.GetBook(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(BookModels book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookModels b = db.GetBook(id);
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
