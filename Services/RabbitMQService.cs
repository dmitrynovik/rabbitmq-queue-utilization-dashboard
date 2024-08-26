
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

    public static QueueMaxLenPolicyUtilization convert(QueueResponse queue) {
        EffectivePolicyDefinition policy = queue.effective_policy_definition;
        var utilization = 0.0;

        if (policy != null) {
            // check utilisation as no. of messages:
            int? maxLength = policy.maxlength;
            if (maxLength != null && maxLength.Value > 0) {
                utilization = (double) queue.messages / maxLength.Value;
            }
            
            // check utlisation as no. of bytes:
            long maxLengthBytes = policy.maxlengthbytes;
            if (maxLengthBytes > 0) {
                var utilisationBytes = (double) queue.message_bytes / maxLengthBytes;
                utilization = Math.Max(utilization, utilisationBytes);
            }
        }

        return new QueueMaxLenPolicyUtilization(queue.vhost, queue.name, utilization);
    }

    private string GetBasicAuthenticationHeader() {
		string auth = rabbitMQConfig.User + ":" + rabbitMQConfig.Password;
		return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
	}
}