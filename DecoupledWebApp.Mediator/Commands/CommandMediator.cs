using DecoupledWebApp.Mediation.Commands.CommandResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecoupledWebApp.Mediation.Commands
{
    public class CommandMediator : ICommandMediator
    {
        internal static Dictionary<string, IEnumerable<Type>> Commands = new Dictionary<string, IEnumerable<Type>>();

        private IMediator _mediator;
        public CommandMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Bind<T, H>() where T : ICommand where H : ICommandHandler
        {
            var command = typeof(T);
            if (!command.GetInterfaces().Contains(typeof(ICommand)))
            {
                throw new NotSupportedException("Command handlers can only be bound to objects that inherit from ICommand");
            }

            var commandName = command.Name;
            var handlerType = typeof(H);
            if (Commands.ContainsKey(commandName))
            {
                var existingHandlers = Commands.First(x => x.Key == commandName).Value.ToList();
                existingHandlers.Add(handlerType);
                Commands.Remove(commandName);
                Commands.Add(commandName, existingHandlers);
            }
            else
            {
                Commands.Add(commandName, new[] { handlerType });
            }
        }

        public CommandResult Execute(ICommand command)
        {
            var commandName = command.GetType().Name;

            if (!Commands.ContainsKey(commandName))
            {
                throw new NullReferenceException(string.Format("No handler has been registered for {0}", commandName));
            }

            var handlers = Commands[commandName];
            return HandleCommand(command, handlers);
        }

        private CommandResult HandleCommand(ICommand command, IEnumerable<Type> handlers)
        {
            try
            {
                foreach (var handler in handlers)
                {
                    var handlerInstance = (ICommandHandler<ICommand>)Activator.CreateInstance(handler);
                    handlerInstance.Mediator = _mediator;
                    var result = ExecuteHandler(command, handlerInstance);
                    if (!result.WasSuccessful)
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return new FailedCommandResult(ex.ToString());
            }

            return new SuccessfulCommandResult();
        }

        private CommandResult ExecuteHandler(ICommand command, ICommandHandler handler)
        {
            if (!handler.UserCanPerformCommand())
            {
                return new ForbiddenCommandResult($"The user cannot execute this command {handler.GetType().Name}.");
            }

            ((ICommandHandler<object>)handler).Handle(command);
            return new SuccessfulCommandResult();
        }
    }
}
