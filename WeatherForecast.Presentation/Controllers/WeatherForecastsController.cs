using Framework.Application.Query;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Queries;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Presentation.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class WeatherForecastsController : ControllerBase
{
    private readonly IQueryBus queryBus;
    
    public WeatherForecastsController(IQueryBus queryBus)
    {
        this.queryBus = queryBus;
    }

    [HttpGet("GetCachedWeatherForecasts")]
    public async Task<IActionResult> GetCachedWeatherForecasts([FromQuery] GetCachedWeatherForecastsQuery query, CancellationToken cancellationToken)
    {
        var result = await queryBus.DispatchAsync<GetCachedWeatherForecastsQuery, List<WeatherForecastViewModel>>(query, cancellationToken);

        return Ok(result);
    }
    
    
    [HttpGet("GetWeatherForecasts")]
    public async Task<IActionResult> GetWeatherForecasts([FromQuery] GetWeatherForecastsQuery query, CancellationToken cancellationToken)
    {
        var result = await queryBus.DispatchAsync<GetWeatherForecastsQuery, List<WeatherForecastViewModel>>(query, cancellationToken);

        return Ok(result);
    }

}