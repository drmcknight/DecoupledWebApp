using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Domain.Users.Queries;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Mediation.Queries;
using System.Collections.Generic;
using System.Linq;

namespace DecoupledWebApp.DAL.Users.Queries
{
    public class GetAllUsersQueryHandler : IQueryHandler<IEnumerable<User>, GetAllUsersQuery>
    {
        public IMediator Mediator { get; set; }

        public IEnumerable<User> Handle(GetAllUsersQuery query)
        {
            return new[]
            {
                new User { ID = 1, Name = "daniel"},
                new User { ID = 2, Name = "holly"}
            }.AsEnumerable();
        }
    }
}
