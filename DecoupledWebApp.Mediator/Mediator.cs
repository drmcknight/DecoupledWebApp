using DecoupledWebApp.Mediation.Commands;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.Mediation
{
    public class Mediator : IMediator
    {
        public IQueryMediator Queries => new QueryMediator(this);

        public ICommandMediator Commands => new CommandMediator(this);
    }
}
