using ElectronicWaybillManagementSystem.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class DependecyInjection
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddVersioning();
            services.AddSwagger();
            services.AddDomainLayer();
            services.AddServicesLayer();
            services.AddDataLayer(configuration);
        }
    }
}
