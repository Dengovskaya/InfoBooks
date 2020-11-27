using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace InfoBooks.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new Collection<Book>();
        }
    }
}