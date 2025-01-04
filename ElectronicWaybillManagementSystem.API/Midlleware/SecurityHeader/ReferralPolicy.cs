namespace ElectronicWaybillManagementSystem.API.Midlleware.SecurityHeader
{
    public class ReferralPolicy
    {
        private readonly RequestDelegate _next;

        public ReferralPolicy(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add the Referrer-Policy header to the response
            context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin"); // Or other policy value
            await _next(context);
        }
    }
}
