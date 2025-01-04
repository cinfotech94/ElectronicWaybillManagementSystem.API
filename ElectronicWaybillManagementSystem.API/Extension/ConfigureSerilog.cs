using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class ConfigureSerilog
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            try
            {
                var elastSearchIndex= builder.Configuration["ELASTIC:INDEX"];
                var mongoDbString= builder.Configuration.GetConnectionString("mongoDb");
                var elastSearchUsername = builder.Configuration["ELASTIC:USERNAME"];
                var elastSearchPwd = builder.Configuration["ELASTIC:PASSWORD"];
                var elastSearchUrl = builder.Configuration["ELASTIC:URI"];
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/ElectronicWayBillMgtServices-logs-{Date}.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                    .WriteTo.Elasticsearch(
                     new ElasticsearchSinkOptions(new Uri(elastSearchUrl))
                     {
                         AutoRegisterTemplate = true,
                         IndexFormat = elastSearchIndex,
                         ModifyConnectionSettings = conn => conn.BasicAuthentication(elastSearchUsername, elastSearchPwd)
                     })
                    .CreateLogger();
                return builder;
            }
            catch(Exception ex)
            {
                return builder;
            }
        }
    }
}
