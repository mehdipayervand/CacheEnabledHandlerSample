namespace Framework.Application.Query;

public interface IQueryBus
{
    Task<TResponse?> DispatchAsync<TQuery,TResponse>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery;
}