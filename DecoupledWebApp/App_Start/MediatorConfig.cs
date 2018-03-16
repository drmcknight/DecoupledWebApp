using DecoupledWebApp.Mediation;
using DecoupledWebApp.DAL.Users.Queries;
using DecoupledWebApp.DAL.Books.Queries;
using DecoupledWebApp.DAL.Books.Commands;
using DecoupledWebApp.Domain.Users.Queries;
using DecoupledWebApp.Domain.Books.Queries;
using DecoupledWebApp.Domain.Queries.Books.Queries;
using DecoupledWebApp.Domain.Books.Commands;

namespace DecoupledWebApp
{
    public class MediatorConfig
    {
        public static void Register(IMediator mediator)
        {
            mediator.Queries.Bind<GetUserByNameQuery, GetUserByNameQueryHandler>();
            mediator.Queries.Bind<GetBookByTitleQuery, GetBookByTitleQueryHandler>();
            mediator.Queries.Bind<GetAllUsersQuery, GetAllUsersQueryHandler>();
            mediator.Queries.Bind<IsBookCheckedOutByUserQuery, IsBookCheckedOutByUserQueryHandler>();

            mediator.Commands.Bind<CheckOutBookCommand, CheckOutBookCommandHandler>();
            mediator.Commands.Bind<CheckOutBookCommand, CheckOutBookCommandHandler>();
        }
    }
}