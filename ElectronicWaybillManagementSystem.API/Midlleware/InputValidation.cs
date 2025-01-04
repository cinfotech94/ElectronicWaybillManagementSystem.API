namespace ElectronicWaybillManagementSystem.API.Midlleware
{
    public class InputValidation
    {
        private readonly RequestDelegate _next;
        public InputValidation(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            foreach(var key in context.Request.Query.Keys)
            {
                string value =context.Request.Query[key];
                if(IsInputValid(value))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input detected");
                    return;
                }
            }
            await _next(context);
        }
        private  bool IsInputValid(string input)
        {
            return input.Contains("\r")||input.Contains("\n");
        }
    }
}
