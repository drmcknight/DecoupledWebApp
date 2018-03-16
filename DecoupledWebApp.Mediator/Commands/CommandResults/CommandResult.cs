namespace DecoupledWebApp.Mediation.Commands.CommandResults
{
    public class CommandResult
    {
        public CommandStatus Status { get; set; }
        public string Message { get; set; }
        public bool WasSuccessful
        {
            get
            {
                return Status == CommandStatus.Succeeded;
            }
        }
    }
}
