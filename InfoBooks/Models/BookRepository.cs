using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InfoBooks.Models
{
    public class BookRepository : IBookRepository<BookModels>
    {
        private BookContext db;

        public BookRepository()
        {
            this.db = new BookContext();
        }

        public IEnumerable<BookModels> GetBookList()
        {

            return db.Books;
        }

        public BookModels GetBook(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(BookModels book)
        {
            db.Books.Add(book);
        }

        public void Update(BookModels book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BookModels book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}