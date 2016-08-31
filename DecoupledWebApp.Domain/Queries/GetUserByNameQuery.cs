using DecoupledWebApp.Mediation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Domain.Queries
{
    public class GetUserByNameQuery : IQuery
    {
        public GetUserByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
