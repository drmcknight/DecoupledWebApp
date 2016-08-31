using DecoupledWebApp.Mediation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Domain.Queries
{
    public class GetBookByTitleQuery : IQuery
    {
        public GetBookByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
    }
}
