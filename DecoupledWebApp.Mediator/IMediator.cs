using DecoupledWebApp.Mediation.Commands;
using DecoupledWebApp.Mediation.Queries;

namespace DecoupledWebApp.Mediation
{
    public interface IMediator
    {
        IQueryMediator Queries { get; }
        ICommandMediator Commands { get; }
    }
}
