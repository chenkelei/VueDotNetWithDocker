using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379"; // redis is the container name of the redis service. 6379 is the default port
    options.InstanceName = "SampleInstance";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/GetCounter", (IDistributedCache cache) =>
{
    string key = "Counter";
    string? result = null;
    try
    {
        var counterStr = cache.GetString(key);
        if (int.TryParse(counterStr, out int counter))
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        result = counter.ToString();
        cache.SetString(key, result);
    }
    catch (RedisConnectionException)
    {
        result = "Redis cache is not found.";
    }
    return result;
})
.WithName("GetCounter");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
