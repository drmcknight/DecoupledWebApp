using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoupledWebApp.Mediation.Queries;
using DecoupledWebApp.Mediation.Commands;
using DecoupledWebApp.Domain.Queries;
using DecoupledWebApp.Domain.Commands;

namespace DecoupledWebApp.Mediation
{
    public static class Mediator
    {
        internal static Dictionary<string, IQueryHandler> Queries = new Dictionary<string, IQueryHandler>();
        internal static Dictionary<string, ICommandHandler> Commands = new Dictionary<string, ICommandHandler>();

        /// <summary>
        /// Binds a QueryHandler to a Query
        /// </summary>
        /// <typeparam name="T">The type expected to be returned by the query</typeparam>
        /// <param name="query">Query object that must inherit from IQuery</param>
        /// <param name="handler">QueryHandler object that must inherit from IQueryHandler</param>
        public static void Register<T>(Type query, IQueryHandler<T> handler)
        {
            if (!query.GetInterfaces().Contains(typeof(IQuery)))
            {
                throw new NotSupportedException("Query handlers can only be bound to objects that inherit from ICommand");
            }

            var queryName = query.Name;

            if (Queries.ContainsKey(queryName))
            {
                throw new NotSupportedException(string.Format("A handler has already been registered for {0}.", queryName));
            }

            Queries.Add(queryName, handler);
        }

        /// <summary>
        /// Binds a CommandHandler to a Command
        /// </summary>
        /// <param name="command">Command object that must inherit from ICommand</param>
        /// <param name="handler">CommandHandler object that must inehrit from ICommandHandler</param>
        public static void Register(Type command, ICommandHandler handler)
        {
            if (!command.GetInterfaces().Contains(typeof(ICommand)))
            {
                throw new NotSupportedException("Command handlers can only be bound to objects that inherit from ICommand");
            }

            var commandName = command.Name;

            if (Commands.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format("A handler has already been registered for {0}.", commandName));
            }

            Commands.Add(commandName, handler);
        }

        /// <summary>
        /// Tells the handler responsible for this command to execute
        /// </summary>
        /// <param name="command"></param>
        public static CommandResult Command(ICommand command)
        {
            var commandName = command.GetType().Name;

            if (!Commands.ContainsKey(commandName))
            {
                throw new NullReferenceException(string.Format("No handler has been registered for {0}", commandName));
            }
            
            var handler = Commands[commandName];

            if (handler.UserCanPerformCommand())
            {
                try
                {
                    return handler.Handle(command);
                }
                catch (Exception ex)
                {
                    return new CommandResult { Status = CommandStatus.Failed, Message = ex.ToString() };
                }
            }

            return new CommandResult { Status = CommandStatus.Forbidden };
        }
    }

    public static class Mediator<T>
    {
        /// <summary>
        /// Tells the handler responsible for this query to execute
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Query(IQuery query)
        {
            var queryName = query.GetType().Name;
            if (Mediator.Queries.ContainsKey(queryName))
            {
                var handler = (IQueryHandler<T>)Mediator.Queries[queryName];
                return handler.Handle(query);
            }

            throw new NullReferenceException(string.Format("A QueryHandler was not bound to {0}.", queryName));
        }
    }
}
