using System;
using DecoupledWebApp.Mediation;
using DecoupledWebApp.Domain.Models;
using DecoupledWebApp.Domain.Queries.Books.Queries;
using DecoupledWebApp.Domain.Books.Commands;
using DecoupledWebApp.Mediation.Commands;
using DecoupledWebApp.Mediation.Commands.CommandResults;

namespace DecoupledWebApp.DAL.Books.Commands
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        public IMediator Mediator { get; set; }

        public CommandResult Handle(ReturnBookCommand command)
        {
            var isCheckedOut = Mediator.Queries.Execute<bool>(new IsBookCheckedOutByUserQuery(new User()));
            if (!isCheckedOut)
            {
                return new FailedCommandResult("The user does not have this book checked out");
            }

            // do stuff to return book

            return new SuccessfulCommandResult();
        }

        public bool UserCanPerformCommand()
        {
            throw new NotImplementedException();
        }
    }
}
