using DecoupledWebApp.Domain.Queries.Books.Queries;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.DAL.Books.Queries
{
    public class IsBookCheckedOutByUserQueryHandler : IQueryHandler<bool, IsBookCheckedOutByUserQuery>
    {
        public IMediator Mediator { get; set; }

        public bool Handle(IsBookCheckedOutByUserQuery query)
        {
            return true;
        }
    }
}
