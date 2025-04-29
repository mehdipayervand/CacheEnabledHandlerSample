namespace Framework.Application.Query;

public interface IQueryHandler<in TQuery,TResponse> where TQuery : IQuery
{
    Task<TResponse?> Handle(TQuery query,CancellationToken cancellationToken);
}
