
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace NotificationAPI.Services
{
    public class KafkaProducer
    {
        private readonly ProducerConfig _config;
        private readonly string _topic;

        // Constructor: Initializes Kafka configuration
        public KafkaProducer(IConfiguration configuration)
        {
            // Set up connection to Kafka broker
            _config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            // Get topic name from configuration
            _topic = configuration["Kafka:Topic"];
        }

        // Method: Sends message to Kafka topic
        public async Task ProduceMessageAsync(string message)
        {
            // Create new producer instance
            using var producer = new ProducerBuilder<Null, string>(_config).Build();

            try
            {
                // Send message to topic
                var result = await producer.ProduceAsync(_topic,
                    new Message<Null, string> { Value = message });

                // Log success with message location
                Console.WriteLine($"Delivered to: {result.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> ex)
            {
                // Handle and log any errors
                Console.WriteLine($"Delivery failed: {ex.Error.Reason}");
            }
        }

        // Method: Creates topic if it doesn't exist
        public async Task CreateTopicIfNotExists()
        {
            // Create admin client for topic management
            using var adminClient = new AdminClientBuilder(
                new AdminClientConfig { BootstrapServers = _config.BootstrapServers }
            ).Build();

            try
            {
                // Create topic with specified configuration
                await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                new TopicSpecification {
                    Name = _topic,              // Topic name
                    ReplicationFactor = 1,      // Single replica for development
                    NumPartitions = 1           // Single partition
                }
            });
            }
            catch (CreateTopicsException)
            {
                // Ignore if topic already exists
            }
        }
    }
}
