using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public virtual Author Author { get; set; }

    }
}