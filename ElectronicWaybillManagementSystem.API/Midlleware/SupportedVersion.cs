using System.Runtime.Intrinsics;

namespace ElectronicWaybillManagementSystem.API.Midlleware
{
    public class SupportedVersion
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public SupportedVersion(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context )
        {
            string supportedVersion = _configuration["supportedVersion"];
            var path = context.Request.Path;
            var pathArray = path.ToString().Split("/");
            int version = 0;
            pathArray.FirstOrDefault(u => u.StartsWith("v") && u.Length == 2 && int.TryParse(((u.ToCharArray())[1]).ToString(), out version));
            if (!supportedVersion.Contains(version.ToString()))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Unsupported version");
                return;
            }
            await _next(context);
        }
    }
}
