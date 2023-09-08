using BlogNoticias.Api.Data;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace BlogNoticias.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<NoticiaContext>();
            
            return services;
        }
    }
}
