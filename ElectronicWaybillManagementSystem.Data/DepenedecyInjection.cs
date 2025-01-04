using ElectronicWaybillManagementSystem.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ElectronicWaybillManagementSystem.Data
{
    public static class DepenedecyInjection
    {
public static void AddDataLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("postgresql")));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var connectionString = configuration.GetConnectionString("mongoDb");
                return new MongoClient(connectionString);
            });
            services.AddSingleton<InOutMongoDbContext>();

        }
    }
}
