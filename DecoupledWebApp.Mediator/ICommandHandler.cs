using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoupledWebApp.Domain.Commands;

namespace DecoupledWebApp.Mediation.Commands
{
    public interface ICommandHandler
    {
        CommandResult Handle(ICommand command);
        bool UserCanPerformCommand();
    }
}
