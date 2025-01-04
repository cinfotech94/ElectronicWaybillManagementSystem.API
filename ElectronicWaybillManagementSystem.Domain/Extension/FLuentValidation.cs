using ElectronicWaybillManagementSystem.Domain.Entities;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class FLuentValidation
    {
        public static void AddFLuentValidation(this IServiceCollection services)
        {
            services.AddControllers()
            .AddFluentValidation(config =>
            {

                config.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>();
            });
            }
    }
}
