using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolyCache.Cache;
using PolyCache.Configuration;
using PolyCache.Infrastructure;

namespace PolyCache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = Singleton<AppSettings>.Instance;
            //var distributedCacheConfig = appSettings.DistributedCacheConfig;

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });

            services.AddScoped<IStaticCacheManager, DistributedCacheManager>();

            //add configuration parameters
            var appSetting = new AppSettings();
            //configuration.Bind(appSetting);
            services.AddSingleton(appSetting);

            //var appOptions = configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = appOptions.RedisConnectionString;
            //});

            return services;
        }
    }
}
