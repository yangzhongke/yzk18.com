using Microsoft.AspNetCore.Builder;
using Zack.EventBus;

namespace MVCCommonInitializer;
public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseZackDefault(this IApplicationBuilder app)
    {
        //app.UseEventBus();
        app.UseCors();//启用Cors
        app.UseForwardedHeaders();
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}