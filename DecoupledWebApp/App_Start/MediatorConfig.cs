using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Commands;
using DecoupledWebApp.DAL.Queries;
using DecoupledWebApp.DAL.Commands;
using DecoupledWebApp.Mediation;

namespace DecoupledWebApp
{
    public class MediatorConfig
    {
        public static void Register()
        {
            Mediator.Register(typeof(GetUserByNameQuery), new GetUserByNameQueryHandler());
            Mediator.Register(typeof(GetBookByTitleQuery), new GetBookByTitleQueryHandler());
            Mediator.Register(typeof(CheckOutBookCommand), new CheckOutBookCommandHandler());
        }
    }
}