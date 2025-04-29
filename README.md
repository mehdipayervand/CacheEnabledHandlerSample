
# 🧠 Caching Query Handlers with Template Method Pattern

This project demonstrates how to implement a reusable caching mechanism for query handlers using the **Template Method Pattern** in .NET.

Instead of repeating cache logic in every handler, we define an abstract base class `CachingDecorator<TQuery, TResponse>` that:
- Checks the cache before hitting the database
- Delegates business logic to the derived handler via `HandleCore`
- Stores the result in cache after execution

## ✨ Benefits

- 🔁 Reusable caching logic
- 🧼 Clean separation of concerns
- ✅ Testable and scalable structure
- 💡 Ideal for performance-sensitive queries

## 📦 Technologies Used

- .NET 8
- ASP.NET Core
- IDistributedCache (In-memory)
- Minimal CQRS Setup
- Dependency Injection
- Template Method Pattern

## 🧪 How It Works

1. Send a query using `IQueryHandler<TQuery, TResponse>`.
2. `CachingDecorator` handles the cache check and stores result after fetching.
3. The child class (e.g. `GetIWeatherForecastsQueryHandler`) implements only `HandleCore`.

```csharp
public class GetIWeatherForecastsQueryHandler 
    : CachingDecorator<GetIWeatherForecastsQuery, List<WeatherForecastViewModel>>
{
    protected override Task<List<WeatherForecastViewModel>> HandleCore(...) { ... }
}
```

## 🛠️ Run the Project

```bash
dotnet run --project WeatherForecast.Presentation
```

Open your browser at `http://localhost:5000` or check the Swagger UI for available endpoints.

## 🔍 Related Design Patterns

- Template Method
- Decorator
- CQRS

## 📎 License

MIT

---

Feel free to fork, contribute or reach out if you have ideas for improvements.  
Happy coding! 🚀
