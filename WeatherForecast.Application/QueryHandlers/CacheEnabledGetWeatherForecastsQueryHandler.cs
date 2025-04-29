using Framework.Core;
using Microsoft.Extensions.Caching.Distributed;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application.QueryHandlers;

public class CacheEnabledGetWeatherForecastsQueryHandler(IDistributedCache cache, ISerializer serializer)
    : CacheEnabledQueryHandler<GetCachedWeatherForecastsQuery, List<WeatherForecastViewModel>>(cache, serializer)
{
    protected override async Task<List<WeatherForecastViewModel>?> HandleCore(
        GetCachedWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        return await DatabaseSample.SimulateGetFromDB();
    }
}