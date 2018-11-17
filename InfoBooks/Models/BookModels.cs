using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InfoBooks.Models
{
    public class BookModels
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthotId { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
    }

    public class BookContext : DbContext
    {
        public BookContext() : base("db")
        { }
        public DbSet<BookModels> Books { get; set; }
    }

    interface IBookRepository<BookModels>: IDisposable
    {
        IEnumerable<BookModels> GetBookList(); // получение всех объектов
        BookModels GetBook(int id); // получение одного объекта по id
        void Create(BookModels item); // создание объекта
        void Update(BookModels item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}