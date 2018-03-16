using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.Domain.Queries.Books.Queries
{
    public class IsBookCheckedOutByUserQuery : IQuery
    {
        public IsBookCheckedOutByUserQuery(User user)
        {
            User = user;
        }

        public User User { get; private set; }
    }
}
