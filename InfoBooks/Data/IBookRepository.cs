using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoBooks.Models;

namespace InfoBooks.Data
{
    public interface IBookRepository
    {
        Book CreateBook(Book book);
        Book GetBookById(int id);
        Book ChangeBook(Book book, int id);

        void DeleteBook(Book book);
        IQueryable<Book> Books { get; }
    }
}
