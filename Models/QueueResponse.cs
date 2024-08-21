// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
using Newtonsoft.Json;

public class AckDetails
    {
        public double rate { get; set; }
    }

    public class Arguments
    {
        [JsonProperty("x-queue-type")]
        public string xqueuetype { get; set; }

        [JsonProperty("x-initial-cluster-size")]
        public int? xinitialclustersize { get; set; }

        [JsonProperty("x-max-age")]
        public string xmaxage { get; set; }

        [JsonProperty("x-max-length-bytes")]
        public long? xmaxlengthbytes { get; set; }
    }

    public class DeliverDetails
    {
        public double rate { get; set; }
    }

    public class DeliverGetDetails
    {
        public double rate { get; set; }
    }

    public class DeliverNoAckDetails
    {
        public double rate { get; set; }
    }

    public class EffectivePolicyDefinition
    {
        [JsonProperty("max-length-bytes")]
        public int maxlengthbytes { get; set; }

        [JsonProperty("remote-dc-replicate")]
        public bool remotedcreplicate { get; set; }

        [JsonProperty("max-length")]
        public int? maxlength { get; set; }
    }

    public class GarbageCollection
    {
        public int fullsweep_after { get; set; }
        public int max_heap_size { get; set; }
        public int min_bin_vheap_size { get; set; }
        public int min_heap_size { get; set; }
        public int minor_gcs { get; set; }
    }

    public class GetDetails
    {
        public double rate { get; set; }
    }

    public class GetEmptyDetails
    {
        public double rate { get; set; }
    }

    public class GetNoAckDetails
    {
        public double rate { get; set; }
    }

    public class MessagesDetails
    {
        public double rate { get; set; }
    }

    public class MessagesReadyDetails
    {
        public double rate { get; set; }
    }

    public class MessageStats
    {
        public int ack { get; set; }
        public AckDetails ack_details { get; set; }
        public int deliver { get; set; }
        public DeliverDetails deliver_details { get; set; }
        public int deliver_get { get; set; }
        public DeliverGetDetails deliver_get_details { get; set; }
        public int deliver_no_ack { get; set; }
        public DeliverNoAckDetails deliver_no_ack_details { get; set; }
        public int get { get; set; }
        public GetDetails get_details { get; set; }
        public int get_empty { get; set; }
        public GetEmptyDetails get_empty_details { get; set; }
        public int get_no_ack { get; set; }
        public GetNoAckDetails get_no_ack_details { get; set; }
        public int publish { get; set; }
        public PublishDetails publish_details { get; set; }
        public int redeliver { get; set; }
        public RedeliverDetails redeliver_details { get; set; }
    }

    public class MessagesUnacknowledgedDetails
    {
        public double rate { get; set; }
    }

    public class OpenFiles
    {
        [JsonProperty("rabbit@rabbitmq-1-upstream-server-0.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int rabbitrabbitmq1upstreamserver0rabbitmq1upstreamnodesrabbitmqsystem { get; set; }

        [JsonProperty("rabbit@rabbitmq-1-upstream-server-1.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int rabbitrabbitmq1upstreamserver1rabbitmq1upstreamnodesrabbitmqsystem { get; set; }

        [JsonProperty("rabbit@rabbitmq-1-upstream-server-2.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int rabbitrabbitmq1upstreamserver2rabbitmq1upstreamnodesrabbitmqsystem { get; set; }
    }

    public class PublishDetails
    {
        public double rate { get; set; }
    }

    public class Readers
    {
        [JsonProperty("rabbit@rabbitmq-1-upstream-server-0.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int rabbitrabbitmq1upstreamserver0rabbitmq1upstreamnodesrabbitmqsystem { get; set; }

        [JsonProperty("rabbit@rabbitmq-1-upstream-server-1.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int rabbitrabbitmq1upstreamserver1rabbitmq1upstreamnodesrabbitmqsystem { get; set; }

        [JsonProperty("rabbit@rabbitmq-1-upstream-server-2.rabbitmq-1-upstream-nodes.rabbitmq-system")]
        public int? rabbitrabbitmq1upstreamserver2rabbitmq1upstreamnodesrabbitmqsystem { get; set; }
    }

    public class RedeliverDetails
    {
        public double rate { get; set; }
    }

    public class ReductionsDetails
    {
        public double rate { get; set; }
    }

    public class Root
    {
        public Arguments arguments { get; set; }
        public bool auto_delete { get; set; }
        public double consumer_capacity { get; set; }
        public double consumer_utilisation { get; set; }
        public int consumers { get; set; }
        public bool durable { get; set; }
        public EffectivePolicyDefinition effective_policy_definition { get; set; }
        public bool exclusive { get; set; }
        public GarbageCollection garbage_collection { get; set; }
        public string leader { get; set; }
        public List<string> members { get; set; }
        public int memory { get; set; }
        public int message_bytes { get; set; }
        public int message_bytes_dlx { get; set; }
        public int message_bytes_persistent { get; set; }
        public int message_bytes_ram { get; set; }
        public int message_bytes_ready { get; set; }
        public int message_bytes_unacknowledged { get; set; }
        public int messages { get; set; }
        public MessagesDetails messages_details { get; set; }
        public int messages_dlx { get; set; }
        public int messages_persistent { get; set; }
        public int messages_ram { get; set; }
        public int messages_ready { get; set; }
        public MessagesReadyDetails messages_ready_details { get; set; }
        public int messages_unacknowledged { get; set; }
        public MessagesUnacknowledgedDetails messages_unacknowledged_details { get; set; }
        public string name { get; set; }
        public string node { get; set; }
        public List<string> online { get; set; }
        public OpenFiles open_files { get; set; }
        public string operator_policy { get; set; }
        public string policy { get; set; }
        public int reductions { get; set; }
        public ReductionsDetails reductions_details { get; set; }
        public object single_active_consumer_tag { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public string vhost { get; set; }
        public object exclusive_consumer_tag { get; set; }
        public object head_message_timestamp { get; set; }
        public DateTime? idle_since { get; set; }
        public int? message_bytes_paged_out { get; set; }
        public int? messages_paged_out { get; set; }
        public int? messages_ready_ram { get; set; }
        public int? messages_unacknowledged_ram { get; set; }
        public object recoverable_slaves { get; set; }
        public int? storage_version { get; set; }
        public Readers readers { get; set; }
        public MessageStats message_stats { get; set; }
    }

