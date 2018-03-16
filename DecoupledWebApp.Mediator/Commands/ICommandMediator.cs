using DecoupledWebApp.Mediation.Commands.CommandResults;

namespace DecoupledWebApp.Mediation.Commands
{
    public interface ICommandMediator
    {
        void Bind<T, H>() where T : ICommand where H : ICommandHandler;
        CommandResult Execute(ICommand command);
    }
}
