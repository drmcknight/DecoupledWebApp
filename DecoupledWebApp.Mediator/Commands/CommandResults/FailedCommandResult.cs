namespace DecoupledWebApp.Mediation.Commands.CommandResults
{
    public class FailedCommandResult : CommandResult
    {
        public FailedCommandResult() : this(string.Empty) { }

        public FailedCommandResult(string message)
        {
            Message = message;
            Status = CommandStatus.Failed;
        }
    }
}
