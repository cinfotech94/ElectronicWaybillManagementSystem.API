namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class Notification
    {
        public Guid id { get; set; }
        public string? message { get; set; }
        public DateTime sentTimestamp { get; set; }
        public string? deliveryMethod { get; set; } // E.g., Email, SMS, Push Notification

        // Foreign Keys
        public Guid userId { get; set; }
        public User user { get; set; } = new User();

        public Guid orderId { get; set; }
        public Order order { get; set; } = new Order();
    }
}