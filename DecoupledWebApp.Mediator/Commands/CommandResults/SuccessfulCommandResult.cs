namespace DecoupledWebApp.Mediation.Commands.CommandResults
{
    public class SuccessfulCommandResult : CommandResult
    {
        public SuccessfulCommandResult() : this(string.Empty) { }

        public SuccessfulCommandResult(string message)
        {
            Message = message;
            Status = CommandStatus.Succeeded;
        }
    }
}
