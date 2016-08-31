using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Mediation;

namespace DecoupledWebApp.DAL.Queries
{
    public class GetUserByNameQueryHandler : IQueryHandler<User>
    {
        public User Handle(IQuery query)
        {
            var name = ((GetUserByNameQuery)query).Name;

            return new User { Name = name };
        }
    }
}
