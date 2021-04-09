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
            services.AddScoped<IStaticCacheManager, DistributedCacheManager>();

            //add configuration parameters
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);
            //AppSettingsHelper.SaveAppSettings(appSettings);

            //nop cache config
            //var appSettings = Singleton<AppSettings>.Instance;
            var distributedCacheConfig = appSettings.DistributedCacheConfig;

            if (!distributedCacheConfig.Enabled)
                return services;

            switch (distributedCacheConfig.DistributedCacheType)
            {
                case DistributedCacheType.Memory:
                    services.AddDistributedMemoryCache();
                    break;

                case DistributedCacheType.SqlServer:
                    services.AddDistributedSqlServerCache(options =>
                    {
                        options.ConnectionString = distributedCacheConfig.ConnectionString;
                        options.SchemaName = distributedCacheConfig.SchemaName;
                        options.TableName = distributedCacheConfig.TableName;
                    });
                    break;

                case DistributedCacheType.Redis:
                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = distributedCacheConfig.ConnectionString;
                    });
                    break;
            }

            //var appSettings = Singleton<AppSettings>.Instance;

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379";
            //});

            //services.AddScoped<IStaticCacheManager, DistributedCacheManager>();

            ////add configuration parameters
            //var appSetting = new AppSettings();
            //services.AddSingleton(appSetting);

            //var appOptions = configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = appOptions.RedisConnectionString;
            //});

            return services;
        }
    }
}
