using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DecoupledWebApp.Domain.Models;

namespace DecoupledWebApp.ViewModels
{
    public class BooksIndexViewModel
    {
        public BooksIndexViewModel(IEnumerable<Book> books)
        {
            Books = books;
        }

        public IEnumerable<Book> Books { get; set; }
    }
}