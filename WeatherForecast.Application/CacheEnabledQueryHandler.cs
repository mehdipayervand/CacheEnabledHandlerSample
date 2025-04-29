using Framework.Application.Query;
using Framework.Core;
using Microsoft.Extensions.Caching.Distributed;

namespace WeatherForecast.Application;

public abstract class CacheEnabledQueryHandler<TQuery, TResponse>(IDistributedCache cache, ISerializer serializer)
    : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery
{
    public async Task<TResponse?> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = GetCacheKey(request);

        var cachedResponse = await cache.GetStringAsync(cacheKey, token: cancellationToken);
        if (!string.IsNullOrEmpty(cachedResponse))
        {
            return serializer.Deserialize<TResponse>(cachedResponse);
        }

        var response = await HandleCore(request, cancellationToken);

        var serializedResponse = serializer.Serialize(response);
        await cache.SetStringAsync(cacheKey, serializedResponse, token: cancellationToken);

        return response;
    }

    protected abstract Task<TResponse?> HandleCore(TQuery request, CancellationToken cancellationToken);

    private string GetCacheKey(TQuery request)
    {
        return $"{typeof(TQuery).FullName}-{request.GetHashCode()}";
    }
}