namespace DecoupledWebApp.Mediation.Queries
{
    public interface IQueryMediator
    {
        void Bind<T, H>() where T : IQuery where H : IQueryHandler;
        T Execute<T>(IQuery query);
    }
}
