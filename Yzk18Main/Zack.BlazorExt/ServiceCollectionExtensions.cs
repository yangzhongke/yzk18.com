using Zack.BlazorExt;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRenderingContext(this IServiceCollection services,bool isPrerendering)
        {
            services.AddSingleton(new RenderingContext(isPrerendering));
            return services;
        }
    }
}
