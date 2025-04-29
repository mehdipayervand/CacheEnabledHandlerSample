using Framework.Application.Query;

namespace WeatherForecast.Infrastructure;

public class QueryBus(IServiceProvider serviceProvider)
    : IQueryBus
{
    public async Task<TResponse?> DispatchAsync<TQuery, TResponse>(
        TQuery query,CancellationToken cancellationToken)
        where TQuery : IQuery
    {
        var handlerType = typeof(IQueryHandler<TQuery, TResponse>);

        var handler = (IQueryHandler<TQuery, TResponse>)serviceProvider.GetService(handlerType)!;
        if (handler == null)
        {
            throw new Exception($"No handler found for query of type {typeof(TQuery).Name}");
        }

        return await handler.Handle(query,cancellationToken);
    }
}