using ElectronicWaybillManagementSystem.Domain.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class DependecyInjection
    {
        public static void AddDomainLayer(this IServiceCollection services)
        {
            services.AddFLuentValidation();

            services.AddAutomapper();

        }
    }
}
