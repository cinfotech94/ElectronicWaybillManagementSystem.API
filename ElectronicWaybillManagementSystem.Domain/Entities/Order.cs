using ElectronicWaybillManagementSystem.Domain.Enums;

namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class Order
    {
        public Guid id { get; set; }
        public string? trackingNumber { get; set; }
        public DateTime? pickupTimestamp { get; set; }
        public DateTime? deliveryTimestamp { get; set; }
        public string? status { get; set; } // E.g., Pending Pickup, In Transit, Delivered
        public string? remarks { get; set; }
        public DateTime lastUpdated { get; set; }

        // Foreign Keys
        public Guid waybillId { get; set; }
        public Waybill waybill { get; set; } = new Waybill();

        // Relationships
        public ICollection<OrderStatus>? statuses { get; set; }
        public ICollection<Notification>? notifications { get; set; }
        public ProofOfDelivery? proofOfDelivery { get; set; }
        public ICollection<Issue>? issues { get; set; }
    }
}