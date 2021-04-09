using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolyCache.Cache;
using PolyCache.Configuration;

namespace PolyCache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPolyCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStaticCacheManager, DistributedCacheManager>();

            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            var distributedCacheConfig = appSettings.DistributedCacheConfig;

            if (!distributedCacheConfig.Enabled)
                return services;

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = distributedCacheConfig.ConnectionString;
            });

            //switch (distributedCacheConfig.DistributedCacheType)
            //{
            //    case DistributedCacheType.Memory:
            //        services.AddDistributedMemoryCache();
            //        break;

            //    case DistributedCacheType.SqlServer:
            //        services.AddDistributedSqlServerCache(options =>
            //        {
            //            options.ConnectionString = distributedCacheConfig.ConnectionString;
            //            options.SchemaName = distributedCacheConfig.SchemaName;
            //            options.TableName = distributedCacheConfig.TableName;
            //        });
            //        break;

            //    case DistributedCacheType.Redis:
            //        services.AddStackExchangeRedisCache(options =>
            //        {
            //            options.Configuration = distributedCacheConfig.ConnectionString;
            //        });
            //        break;
            //}

            return services;
        }
    }
}
