using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoBooks.Models;

namespace InfoBooks.Data
{
    public class EfAuthourRepository : IAuthorRepository
    {
        EfDbContext context;

        IQueryable<Author> IAuthorRepository.Authors
        {
            get
            {
                return context.Authors;
            }
        }

        public EfAuthourRepository()
        {
            context = new EfDbContext();
        }

        public Author ChangeAuthour(string name, int id)
        {
            Author oldAuthor = GetAuthourById(id);
            oldAuthor.AuthorName = name;
            context.SaveChanges();
            return oldAuthor;
        }

        public Author GetAuthorByName(string name)
        {
            return context.Authors.First(x => x.AuthorName == name);
        }

        public Author CreateAuthor(Author author)
        {
            Author newA = context.Authors.Add(author);
            context.SaveChanges();
            return newA;
        }

        public Author GetAuthourById(int id)
        {
            return context.Authors.Find(id);
        }

        public void DeleteAuthor(Author author)
        {
            Author authorDel = GetAuthourById(author.Id);
            context.Authors.Remove(authorDel);
            context.SaveChanges();
        }
    }
}