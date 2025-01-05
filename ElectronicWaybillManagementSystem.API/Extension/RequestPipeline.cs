using ElectronicWaybillManagementSystem.API.Midlleware;
using ElectronicWaybillManagementSystem.API.Midlleware.SecurityHeader;
using ElectronicWaybillManagementSystem.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ElectronicWaybillManagementSystem.API.Extension
{
    public static class RequestPipeline
    {
        public static async void ConfigureRequestPipeline(this WebApplication app, IWebHostEnvironment env)
        {
            try
            {
                RequestPipeline.ApplyMigration(app);
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
        public static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
