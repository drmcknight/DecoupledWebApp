using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Domain.Books.Queries;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.DAL.Books.Queries
{
    public class GetBookByTitleQueryHandler : IQueryHandler<Book, GetBookByTitleQuery>
    {
        public IMediator Mediator { get; set; }

        public Book Handle(GetBookByTitleQuery query)
        {
            var title = query.Title;
            return new Book { Title = title };
        }
    }
}