using ElectronicWaybillManagementSystem.Domain.Entities;

namespace ElectronicWaybillManagementSystem.Domain.Enums
{
    public enum OrderStatus
    {
        pending,
        pickup,
        in_transit,
        delivered,
        //public Guid id { get; set; }
        //public string? status { get; set; } // E.g., Pending Pickup, In Transit
        //public DateTime timestamp { get; set; }
        //public string? location { get; set; } // Optional GPS or description

        //// Foreign Keys
        //public Guid orderId { get; set; }
        //public Order order { get; set; } = new Order();

        //public Guid updatedById { get; set; }
        //public User updatedBy { get; set; } = new User();
    }
}