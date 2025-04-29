﻿using Framework.Core;
using Newtonsoft.Json;

namespace WeatherForecast.Infrastructure;

public class JsonSerializer : ISerializer
{
    public string Serialize<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public T? Deserialize<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}