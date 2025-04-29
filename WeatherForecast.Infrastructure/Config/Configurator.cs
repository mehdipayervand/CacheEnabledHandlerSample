using Framework.Application.Query;
using Framework.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.QueryHandlers;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Infrastructure.Config;

public static class Configurator
{
    public static void ConfigApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedMemoryCache();

        services.AddSingleton<ISerializer, JsonSerializer>();
        
        services.AddScoped<IQueryBus, QueryBus>();

        services.AddScoped<IQueryHandler<GetWeatherForecastsQuery, List<WeatherForecastViewModel>>, GetWeatherForecastsQueryHandler>();
        services.AddScoped<IQueryHandler<GetCachedWeatherForecastsQuery, List<WeatherForecastViewModel>>, CacheEnabledGetWeatherForecastsQueryHandler>();
    }
}