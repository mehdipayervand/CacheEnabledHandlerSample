using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application;

public class DatabaseSample
{
    public static async Task<List<WeatherForecastViewModel>> SimulateGetFromDB()
    {
        Task.Delay(2000).Wait();

        var result = new List<WeatherForecastViewModel>();
        for (int i = 0; i < 10; i++)
        {
            int temperatureC = Random.Shared.Next(-32, 33);
            int temperatureF = (int)((temperatureC * 9.5) + 32);
            result.Add(new WeatherForecastViewModel(DateTime.Now.AddDays(i * -1), temperatureC, temperatureF));
        }

        return await Task.FromResult(result);
    }
}