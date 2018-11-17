using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InfoBooks.Models
{
    public class AuthorModels
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }

    public class AuthorContext : DbContext
    {
        public AuthorContext() : base("db")
        { }
        public DbSet<AuthorModels> Author { get; set; }
    }

    interface IAuthorRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAuthorList(); // получение всех объектов
        T GetAuthor(int id); // получение одного объекта по id

        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}