using ElectronicWaybillManagementSystem.Data.Context;
using ElectronicWaybillManagementSystem.Domain.DTO.Common;

namespace ElectronicWaybillManagementSystem.API.Midlleware
{
    public class InboundLoging
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly InOutMongoDbContext inOutMongoDbContext;
        public InboundLoging(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }
        public async Task InvokeAsync(HttpContext context, InOutMongoDbContext inOutMongoDbContext)
        {
            string newQueryKey = "correlationid";
            Guid newQueryValue= Guid.NewGuid();
            var request = context.Request;
            context.Request.EnableBuffering();
            var inboundLog = new InboundLog()
            {
                aPICalled = context.Request.Path.ToString(),
                requestDateTime = DateTime.Now,
                requestDetails = request.QueryString.ToString() + string.Join("; ", request.Headers.Select(x => x.Key)) ?? "",
                ip = context.Connection.RemoteIpAddress?.ToString() ?? "",
                correlationId = newQueryValue.ToString()
            };
            await inOutMongoDbContext.InboundLogs.InsertOneAsync(inboundLog);
            var queryDictionary =request.Headers[newQueryKey]=newQueryValue.ToString();
            await _next(context);
        }
    }
}
