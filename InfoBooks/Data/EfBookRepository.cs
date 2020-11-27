using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoBooks.Models;

namespace InfoBooks.Data
{
    public class EfBookRepository : IBookRepository
    {
        EfDbContext context;
        public EfBookRepository()
        {
            context = new EfDbContext();
        }

        public IQueryable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }

        public Book ChangeBook(Book book, int id)
        {
            Book oldBook = GetBookById(id);
            
            oldBook.Price = book.Price;
            oldBook.Year = book.Year;
            oldBook.BookName = book.BookName;
            oldBook.AuthorId = book.AuthorId;//TODO
            context.SaveChanges();
            return oldBook;
        }

        public Book CreateBook(Book book)
        {
            Book newBook = context.Books.Add(book);
            context.SaveChanges();
            return newBook;
        }

        public Book GetBookById(int id)
        {
            return context.Books.Find(id);
        }

        public void DeleteBook(Book book)
        {
            Book bookDel = GetBookById(book.Id);
            context.Books.Remove(bookDel);
            context.SaveChanges();
        }
    }
}