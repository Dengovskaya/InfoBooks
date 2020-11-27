using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoBooks.Models;
using System.Data.Entity;

namespace InfoBooks.Data
{
    public class EfDbContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}