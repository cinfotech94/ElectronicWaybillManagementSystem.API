namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class Issue
    {
        public int id { get; set; }
        public string? issueDescription { get; set; }
        public string? status { get; set; } // E.g., Open, In Progress, Resolved
        public DateTime createdTimestamp { get; set; }
        public DateTime? resolvedTimestamp { get; set; }

        // Foreign Keys
        public Guid orderId { get; set; }
        public Order order { get; set; } = new Order();

        public Guid reportedById { get; set; }
        public User reportedBy { get; set; } = new User();

        public Guid resolvedById { get; set; }
        public User resolvedBy { get; set; } = new User();
    }
}