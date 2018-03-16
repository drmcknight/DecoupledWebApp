using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Domain.Users.Queries;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.DAL.Users.Queries
{
    public class GetUserByNameQueryHandler : IQueryHandler<User, GetUserByNameQuery>
    {
        public IMediator Mediator { get; set; }

        public User Handle(GetUserByNameQuery query)
        {
            var name = query.Name;

            return new User { Name = name };
        }
    }
}
