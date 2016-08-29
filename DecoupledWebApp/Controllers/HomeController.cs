using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Commands;

namespace DecoupledWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var user = Mediator<User>.Query(new GetUserByNameQuery("daniel"));
            var book = Mediator<Book>.Query(new GetBookByTitleQuery("white fang"));
            var result = Mediator.Command(new CheckOutBookCommand(user.Name, book.Title));

            return View();
        }
    }
}