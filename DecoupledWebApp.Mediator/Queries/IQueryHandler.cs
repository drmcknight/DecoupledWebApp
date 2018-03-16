namespace DecoupledWebApp.Mediation.Queries
{
    public interface IQueryHandler<T, Q> : IQueryHandler
    {
        T Handle(Q query);
    }

    public interface IQueryHandler
    {
        IMediator Mediator { get; set; }
    }
}
