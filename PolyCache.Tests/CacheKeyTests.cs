using PolyCache.Cache;

namespace PolyCache.Tests
{
    [TestFixture]
    public class CacheKeyTests
    {
        [Test]
        public void Constructor_ShouldInitializeKeyAndPrefixes()
        {
            var cacheKey = new CacheKey("testKey", "prefix1", "prefix2");

            Assert.AreEqual("testKey", cacheKey.Key);
            Assert.Contains("prefix1", cacheKey.Prefixes);
            Assert.Contains("prefix2", cacheKey.Prefixes);
        }

        [Test]
        public void Create_ShouldReturnNewCacheKeyWithFormattedKeyAndPrefixes()
        {
            var cacheKey = new CacheKey("{0}Key", "{0}Prefix");
            var newCacheKey = cacheKey.Create(o => o.ToString(), "test");

            Assert.AreEqual("testKey", newCacheKey.Key);
            Assert.Contains("testPrefix", newCacheKey.Prefixes);
        }

        [Test]
        public void Create_ShouldReturnNewCacheKeyWithSameKeyAndPrefixes_WhenNoKeyObjectsProvided()
        {
            var cacheKey = new CacheKey("testKey", "testPrefix");
            var newCacheKey = cacheKey.Create(o => o.ToString());

            Assert.AreEqual("testKey", newCacheKey.Key);
            Assert.Contains("testPrefix", newCacheKey.Prefixes);
        }
    }
}
