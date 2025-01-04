using Asp.Versioning;
using Microsoft.Extensions.Options;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class ConfigureVersioning
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
             {
                 options.DefaultApiVersion = new ApiVersion(1, 0);
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.ApiVersionReader = new HeaderApiVersionReader();
                 options.ReportApiVersions = true;
             }).AddApiExplorer(options =>
             {
                 options.GroupNameFormat = "'v'V";
                 options.SubstituteApiVersionInUrl = true;
             });
             
        }
    }
}
