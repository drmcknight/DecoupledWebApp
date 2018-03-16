using DecoupledWebApp.Mediation.Commands.CommandResults;

namespace DecoupledWebApp.Mediation.Commands
{
    public interface ICommandHandler<C> : ICommandHandler
    {
        CommandResult Handle(C command);
    }

    public interface ICommandHandler
    {
        IMediator Mediator { get; set; }
        bool UserCanPerformCommand();
    }
}
