namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class ProofOfDelivery
    {
        public Guid id { get; set; }
        public DateTime deliveryTimestamp { get; set; }
        public string? recipientName { get; set; }


        /// <summary>
        /// Are these necessary?
        /// </summary>
        //public byte[] RecipientSignature { get; set; } // Optional (Binary data)
        //public byte[] Photo { get; set; } // Optional (Binary data)

        // Foreign Keys
        public Guid orderId { get; set; }
        public Order order { get; set; } = new Order();
    }
}