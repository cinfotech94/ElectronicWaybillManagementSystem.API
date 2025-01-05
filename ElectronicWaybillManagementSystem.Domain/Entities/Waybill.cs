using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class Waybill
    {
        public Guid id { get; set; }
        public DateTime pickupDate { get; set; }
        public string? senderName { get; set; }
        public string? senderPhone { get; set; }
        public string? receiverName { get; set; }
        public string? receiverPhone { get; set; }
        public string? pickupAddress { get; set; }
        public string? deliveryAddress { get; set; }
        public string? orderDescription { get; set; }
        public double weight { get; set; }
        public decimal deliveryFee { get; set; }
        public string? status { get; set; } // E.g., Created, In Transit, Delivered
        public DateTime lateCreated { get; set; }
        public DateTime lastUpdated { get; set; }

        // Foreign Keys
        public Guid createdById { get; set; }
        public User createdBy { get; set; } = new User();

        public Guid assignedToId { get; set; }
        public User assignedTo { get; set; } = new User();

        // Relationships
        public ICollection<Order>? orders { get; set; }

    }
}
