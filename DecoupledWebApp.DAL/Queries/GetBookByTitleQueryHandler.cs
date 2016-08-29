using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Mediation.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.DAL.Queries
{
    public class GetBookByTitleQueryHandler : IQueryHandler<Book>
    {
        public Book Handle(IQuery query)
        {
            // i don't like having to do this cast...
            var title = ((GetBookByTitleQuery)query).Title;
            return new Book { Title = title };
        }
    }
}