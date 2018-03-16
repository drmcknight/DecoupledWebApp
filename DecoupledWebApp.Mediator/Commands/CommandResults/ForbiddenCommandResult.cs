namespace DecoupledWebApp.Mediation.Commands.CommandResults
{
    class ForbiddenCommandResult : CommandResult
    {
        public ForbiddenCommandResult() : this(string.Empty) { }

        public ForbiddenCommandResult(string message)
        {
            Message = message;
            Status = CommandStatus.Forbidden;
        }
    }
}
