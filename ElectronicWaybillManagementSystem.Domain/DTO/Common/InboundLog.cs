

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

namespace ElectronicWaybillManagementSystem.Domain.DTO.Common
{
    public class InboundLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public ObjectId inboundLogId { get; set; }=ObjectId.GenerateNewId();    
        public string? ip { get; set; }
        public string? correlationId { get; set; }
        public string? aPICalled { get; set; }
        public string? requestDetails { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime requestDateTime { get; set; }
        public string? exceptionDetails { get; set; }
        public ObjectId? outboundLogId { get; set; }
        public ConcurrentBag<OutboundLog>? outboundLog { get; set; } =new ConcurrentBag<OutboundLog>();
        

    }
}
