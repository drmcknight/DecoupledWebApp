using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoupledWebApp.Domain.Queries;

namespace DecoupledWebApp.Mediation.Queries
{
    public interface IQueryHandler<T> : IQueryHandler
    {
        T Handle(IQuery query);
    }

    public interface IQueryHandler { }
}
