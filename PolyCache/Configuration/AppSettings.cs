namespace PolyCache.Configuration
{
    public class AppSettings
    {
        public CacheConfig CacheConfig { get; set; } = new CacheConfig();

        public DistributedCacheConfig DistributedCacheConfig { get; set; } = new DistributedCacheConfig();
    }
}
