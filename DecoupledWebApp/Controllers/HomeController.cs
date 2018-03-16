using System.Collections.Generic;
using System.Web.Mvc;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.ViewModels;
using DecoupledWebApp.Domain.Users.Queries;

namespace DecoupledWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        public HomeController()
        {
            _mediator = new Mediator();
        }

        // GET: Home
        public ActionResult Index()
        {
            var user = _mediator.Queries.Execute<IEnumerable<User>>(new GetAllUsersQuery());

            return View(new IndexViewModel(user));
        }
    }
}