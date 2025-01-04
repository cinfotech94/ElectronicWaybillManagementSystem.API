using ElectronicWaybillManagementSystem.API.Midlleware;
using ElectronicWaybillManagementSystem.API.Midlleware.SecurityHeader;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class RequestPipeline
    {
        public static async void ConfigureRequestPipeline(this WebApplication app, IWebHostEnvironment env)
        {
            try
            {
                app.UseMiddleware<InboundLoging>();
                //app.UseMiddleware<ContentSecurityPolicy>();
                //app.UseMiddleware<PermissionPolicy>();
                app.UseMiddleware<ReferralPolicy>();
                app.UseMiddleware<StrictTransportPolicy>();
                app.UseMiddleware<XContentTypeOptions>();
                app.UseMiddleware<XframeOptions>();
                //app.UseMiddleware<Correlation>();
                app.UseMiddleware<InputValidation>();
                app.UseMiddleware<SupportedVersion>();
                if (!app.Environment.IsDevelopment())
                {

                    app.UseHsts();
                }
                app.UseHttpsRedirection();

                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseAuthentication();
                app.UseAuthorization();
                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
