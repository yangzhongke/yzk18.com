using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Serilog;
using Zack.Commons;

namespace MVCCommonInitializer;
public static class WebApplicationBuilderExtensions
{
    public static void ConfigureDbConfiguration(this WebApplicationBuilder builder)
    {
        builder.Host.ConfigureAppConfiguration((hostCtx, configBuilder) =>
        {
            string connStr = builder.Configuration.GetValue<string>("DefaultDB:ConnStr");
            configBuilder.AddDbConfiguration(() => new MySqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(5));
        });
    }

    public static void ConfigureExtraServices(this WebApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;
        IConfiguration configuration = builder.Configuration;
        var assemblies = ReflectionHelper.GetAllReferencedAssemblies();
        //var assemblies = new Assembly[] {typeof(Articles.Infrastructure.ModuleInitializer).Assembly, typeof(Identities.Infrastructure.IdDbContext).Assembly };
        services.RunModuleInitializers(assemblies);
        services.AddAllDbContexts(ctx =>
        {
            //连接字符串如果放到appsettings.json中，会有泄密的风险
            //如果放到UserSecrets中，每个项目都要配置，很麻烦
            //因此这里推荐放到环境变量中。
            string connStr = configuration.GetValue<string>("DefaultDB:ConnStr");
            ctx.UseMySql(connStr, ServerVersion.Parse("5.6.16"));
        }, assemblies);

        //开始:Authentication,Authorization
        //只要需要校验Authentication报文头的地方（非IdentityService.WebAPI项目）也需要启用这些
        //IdentityService项目还需要启用AddIdentityCore
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();
        //结束:Authentication,Authorization
        services.AddMediatR(assemblies);
        services.AddLogging(builder =>
        {
            Log.Logger = new LoggerConfiguration()
               // .MinimumLevel.Information().Enrich.FromLogContext()
               .WriteTo.Console()
               .WriteTo.File("yzk18admin.log")
               .CreateLogger();
            builder.AddSerilog();
        });
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
        });
    }
}