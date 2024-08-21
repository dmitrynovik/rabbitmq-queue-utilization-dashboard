using Steeltoe.Common.Hosting;
using Steeltoe.Connector.RabbitMQ;
using Steeltoe.Extensions.Logging;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;

var builder = WebApplication.CreateBuilder(args)
    .UseCloudHosting(55822)
;

builder.Logging.AddDynamicConsole();

builder.Services.AddRabbitMQConnection(builder.Configuration);
builder.Services.AddAllActuators(builder.Configuration);
builder.Services.ActivateActuatorEndpoints();
builder.Services.AddDistributedTracingAspNetCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<LoggerFactory>();

builder.Services.AddSingleton<RabbitMQConfig>();
builder.Services.AddSingleton<RabbitMQService>();
builder.Services.AddSingleton<MetricsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast").WithOpenApi();

var metricsService = app.Services.GetService<MetricsService>();
await metricsService.StartAsync(CancellationToken.None);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
