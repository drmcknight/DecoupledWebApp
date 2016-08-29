using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoupledWebApp.Domain.Commands
{
    public class CommandResult
    {
        public CommandStatus Status { get; set; }
        public string Message { get; set; }
    }

    public enum CommandStatus
    {
        Succeeded,
        Failed,
        Forbidden
    }
}
