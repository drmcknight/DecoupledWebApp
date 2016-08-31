using DecoupledWebApp.Domain.Commands;
using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Mediation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecoupledWebApp.DAL.Commands
{
    public class CheckOutBookCommandHandler : ICommandHandler
    {
        public CommandResult Handle(ICommand command)
        {
            var cmd = (CheckOutBookCommand)command;

            var user = Mediator<User>.Query(new GetUserByNameQuery(cmd.UserName));

            var checkedOutBook = new Book { Title = cmd.BookTitle, CurrentOwner = user };
            // save checked out book
            return new CommandResult { Status = CommandStatus.Succeeded };
        }

        public bool UserCanPerformCommand()
        {
            return true;
        }
    }
}
