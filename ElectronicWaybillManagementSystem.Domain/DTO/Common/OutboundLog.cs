using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicWaybillManagementSystem.Domain.DTO.Common
{
    public class OutboundLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public ObjectId outboundLogId { get; set; }=ObjectId.GenerateNewId();
        public string? aPIMethod { get; set; }
        public string? correlationId { get; set; }
        public string? responseDetails { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime responseDateTime { get; set; }
        public string? exceptionDetails { get; set; }
        public ObjectId? inboundLogId { get; set; } 
        public ConcurrentBag<InboundLog>? inboundLog { get; set; }=new ConcurrentBag<InboundLog>();
    }
}
