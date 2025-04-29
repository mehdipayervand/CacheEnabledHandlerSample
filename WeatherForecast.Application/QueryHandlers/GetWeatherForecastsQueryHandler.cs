using Framework.Application.Query;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application.QueryHandlers;

public class GetWeatherForecastsQueryHandler : IQueryHandler<GetWeatherForecastsQuery, List<WeatherForecastViewModel>>
{
    public async Task<List<WeatherForecastViewModel>?> Handle(
        GetWeatherForecastsQuery query, CancellationToken cancellationToken)
    {
        return await DatabaseSample.SimulateGetFromDB();
    }

}