using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.Domain.Books.Queries
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
