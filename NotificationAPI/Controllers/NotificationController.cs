using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Model;
using NotificationAPI.Services;
using System.Text.Json;

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly KafkaProducer _producer;

        // Constructor: Injects KafkaProducer service
        public NotificationController(KafkaProducer producer)
        {
            _producer = producer;
        }

        // Endpoint: Receives and publishes notifications
        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] Notification notification)
        {
            // Serialize notification to JSON and send to Kafka
            await _producer.ProduceMessageAsync(JsonSerializer.Serialize(notification));
            return Ok();
        }
    }
}
