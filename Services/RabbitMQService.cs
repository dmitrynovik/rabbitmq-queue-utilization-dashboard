
using System.Text;
using Newtonsoft.Json;

public class RabbitMQService {
    private readonly RabbitMQConfig rabbitMQConfig;
    private readonly HttpClient httpClient;
    private readonly ILogger<RabbitMQService> log;

    public RabbitMQService(RabbitMQConfig rabbitMQConfig, HttpClient httpClient, ILoggerFactory loggerFactory) {
        this.rabbitMQConfig = rabbitMQConfig;

        this.httpClient = httpClient;
        httpClient.DefaultRequestHeaders.Add("Authorization", GetBasicAuthenticationHeader());

        log = loggerFactory.CreateLogger<RabbitMQService>();
    }

    public async Task<QueueResponse[]> getQueues() {
        const string path = "/api/queues";
        string uri = rabbitMQConfig.GetUrl() + path;

        log.LogInformation("GET " + uri);
        var response = await httpClient.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<QueueResponse[]>(response);    
    }

    private string GetBasicAuthenticationHeader() {
		string auth = rabbitMQConfig.User + ":" + rabbitMQConfig.Password;
		return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
	}
}