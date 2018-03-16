using System;
using System.Collections.Generic;
using System.Linq;

namespace DecoupledWebApp.Mediation.Queries
{
    public class QueryMediator : IQueryMediator
    {
        internal static Dictionary<string, Type> Queries = new Dictionary<string, Type>();

        private IMediator _mediator;
        public QueryMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Bind<T, H>()where T : IQuery where H : IQueryHandler
        {
            var query = typeof(T);
            if (!query.GetInterfaces().Contains(typeof(IQuery)))
            {
                throw new NotSupportedException("Query handlers can only be bound to objects that inherit from ICommand");
            }

            var queryName = query.Name;

            if (Queries.ContainsKey(queryName))
            {
                throw new NotSupportedException(string.Format("A handler has already been registered for {0}.", queryName));
            }

            Queries.Add(queryName, typeof(H));
        }

        public T Execute<T>(IQuery query)
        {
            var queryName = query.GetType().Name;
            if (Queries.ContainsKey(queryName))
            {
                var handlerType = Queries[queryName];
                var handlerInstance = Activator.CreateInstance(handlerType);
                var property = handlerType.GetProperty("Mediator");
                property.SetValue(handlerInstance, _mediator);
                var methodInfo = handlerType.GetMethod("Handle");
                return (T)methodInfo.Invoke(handlerInstance, new[] { query });
            }

            throw new NullReferenceException(string.Format("A QueryHandler was not bound to {0}.", queryName));
        }
    }
}
