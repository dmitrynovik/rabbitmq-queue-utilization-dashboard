* Unzip steeltoe initialzr download
* Modify kestrel port in `appsettings.json`:
```
"Kestrel": {
    "Endpoints": {
      "MyHttpEndpoint": {
        "Url": "http://localhost:5001"
      }
    }
  }
```
* Generate JSON classes using [converter](https://json2csharp.com/)
* `using Newtonsoft.Json;`
* Rename `Root` to `QueueResponse`
* Add reference to Newtonsoft.Json: `dotnet add package Newtonsoft.Json -v 13.0.3`
* Add reference to Newtonsoft.Json: `dotnet add packageMicrosoft.Extensions.Logging`
* Add `RabbitMQ config`, `RabbitMQService`
* Add `MetricsService`
```
builder.Services.AddHttpClient();
builder.Services.AddSingleton<LoggerFactory>();

builder.Services.AddSingleton<RabbitMQConfig>();
builder.Services.AddSingleton<RabbitMQService>();
builder.Services.AddSingleton<LokiConfig>();
builder.Services.AddSingleton<LokiService>();
builder.Services.AddSingleton<MetricsConfig>();
builder.Services.AddSingleton<MetricsService>();
```

```
var metricsService = app.Services.GetService<MetricsService>();
await metricsService.StartAsync(CancellationToken.None);

```


