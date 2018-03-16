using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.Domain.Users.Queries
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
