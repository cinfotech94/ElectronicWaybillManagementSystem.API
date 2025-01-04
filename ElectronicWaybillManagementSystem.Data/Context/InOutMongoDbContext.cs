using ElectronicWaybillManagementSystem.Domain.DTO.Common;
using ElectronicWaybillManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWaybillManagementSystem.Data.Context
{
    public class InOutMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public InOutMongoDbContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("mongoDb"));
            _database = mongoClient.GetDatabase("inOutBoudLog");
        }

        public IMongoCollection<InboundLog> InboundLogs => _database.GetCollection<InboundLog>("inboundLogs");
        public IMongoCollection<OutboundLog> OutboundLogs => _database.GetCollection<OutboundLog>("outboundLogs");

        // You can add more methods to interact with MongoDB collections as needed
    }
}

