using Articles.Domain;
using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace Articles.Infrastructure
{
    internal class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
        }
    }
}
