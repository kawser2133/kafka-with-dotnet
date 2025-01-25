namespace NotificationAPI.Model
{
    public class Notification
    {
        public string UserId { get; set; }    // Recipient identifier
        public string Message { get; set; }    // Message content
        public string Type { get; set; }       // Notification category
        public DateTime Timestamp { get; set; } // Creation time
    }
}