using Confluent.Kafka;
using NotificationAPI.Model;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Configure consumer settings
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",     // Kafka server address
            GroupId = "notification-group",          // Consumer group name
            AutoOffsetReset = AutoOffsetReset.Earliest  // Start from oldest message
        };

        // Create consumer instance
        using var consumer = new ConsumerBuilder<Null, string>(config).Build();

        // Subscribe to topic
        consumer.Subscribe("notifications");

        try
        {
            // Continuous message consumption loop
            while (true)
            {
                // Read message from topic
                var result = consumer.Consume();

                // Deserialize JSON message to Notification object
                var notification = JsonSerializer.Deserialize<Notification>(
                    result.Message.Value
                );

                // Display notification details
                Console.WriteLine($"User: {notification?.UserId}");
                Console.WriteLine($"Message: {notification?.Message}");
                Console.WriteLine($"Type: {notification?.Type}");
                Console.WriteLine($"Time: {notification?.Timestamp}");
                Console.WriteLine("-------------------");
            }
        }
        catch (OperationCanceledException)
        {
            // Clean shutdown
            consumer.Close();
        }
    }
}