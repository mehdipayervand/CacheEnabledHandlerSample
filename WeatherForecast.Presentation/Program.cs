using WeatherForecast.Infrastructure.Config;

namespace WeatherForecast.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigApplication(builder.Configuration);
        
        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.Run();
    }
}