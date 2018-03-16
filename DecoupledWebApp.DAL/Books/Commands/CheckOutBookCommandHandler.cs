using DecoupledWebApp.Domain.Books.Commands;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Domain.Users.Queries;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Mediation.Commands;
using DecoupledWebApp.Mediation.Commands.CommandResults;

namespace DecoupledWebApp.DAL.Books.Commands
{
    public class CheckOutBookCommandHandler : ICommandHandler<CheckOutBookCommand>
    {
        public IMediator Mediator { get; set; }

        public CommandResult Handle(CheckOutBookCommand command)
        {
            var user = Mediator.Queries.Execute<User>(new GetUserByNameQuery(command.UserName));

            var checkedOutBook = new Book { Title = command.BookTitle, CurrentOwner = user };
            // save checked out book
            return new SuccessfulCommandResult();
        }

        public bool UserCanPerformCommand()
        {
            return false;
        }
    }
}
