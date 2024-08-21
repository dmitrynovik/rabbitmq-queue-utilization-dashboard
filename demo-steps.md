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
* add reference to Newtonsoft.Json: `dotnet add package Newtonsoft.Json -v 13.0.3`
* add `RabbitMQ config`, `RabbitMQService`
```
builder.Services.AddSingleton<RabbitMQConfig>();
builder.Services.AddSingleton<RabbitMQService>();

```


