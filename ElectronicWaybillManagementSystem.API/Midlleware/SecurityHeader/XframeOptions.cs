namespace ElectronicWaybillManagementSystem.API.Midlleware.SecurityHeader
{
    public class XframeOptions
    {
        private readonly RequestDelegate _next;

        public XframeOptions(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add the X-Frame-Options header to the response
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            await _next(context);
        }
    }
}
