using System.Collections.Generic;
using System.Web.Mvc;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.ViewModels;
using DecoupledWebApp.Domain.Books.Queries;
using DecoupledWebApp.Domain.Books.Commands;

namespace DecoupledWebApp.Controllers
{
    public class BooksController : Controller
    {
        private IMediator _mediator;
        public BooksController()
        {
            _mediator = new Mediator();
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _mediator.Queries.Execute<IEnumerable<Book>>(new GetAllBooksQuery());
            return View(new BooksIndexViewModel(books));
        }

        public ActionResult ReturnBook(int bookID)
        {
            var result = _mediator.Commands.Execute(new ReturnBookCommand(bookID));
            if (!result.WasSuccessful)
            {
                //do one thing
            }

            return View();
        }
    }
}