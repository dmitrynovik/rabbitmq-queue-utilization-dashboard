* Unzip steeltoe initialzr download
* Modify kestreal port in `appsettings.json`:
```
"Kestrel": {
    "Endpoints": {
      "MyHttpEndpoint": {
        "Url": "http://localhost:5001"
      }
    }
  }
```
* Generate JSON classes
* `using Newtonsoft.Json;`
* add reference to Newtonsoft.Json: `dotnet add package Newtonsoft.Json -v 13.0.3`

