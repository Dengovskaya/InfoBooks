using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InfoBooks.Models
{
    public class AuthorRepository: IAuthorRepository<AuthorModels>
    {
        private AuthorContext db;

        public AuthorRepository()
        {
            this.db = new AuthorContext();
        }

        public IEnumerable<AuthorModels> GetAuthorList()
        {
            return db.Author;
        }

        public AuthorModels GetAuthor(int id)
        {
            return db.Author.Find(id);
        }

        public void Create(AuthorModels author)
        {
            db.Author.Add(author);
        }

        public void Update(AuthorModels author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AuthorModels author = db.Author.Find(id);
            if (author != null)
                db.Author.Remove(author);
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