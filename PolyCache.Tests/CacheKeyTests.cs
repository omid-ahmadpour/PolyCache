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

            Assert.That("testKey", Is.EqualTo(cacheKey.Key));
            Assert.That(cacheKey.Prefixes, Has.Member("prefix1"));
            Assert.That(cacheKey.Prefixes, Has.Member("prefix2"));
        }

        [Test]
        public void Create_ShouldReturnNewCacheKeyWithFormattedKeyAndPrefixes()
        {
            var cacheKey = new CacheKey("{0}Key", "{0}Prefix");
            var newCacheKey = cacheKey.Create(o => o.ToString(), "test");

            Assert.That("testKey", Is.EqualTo(newCacheKey.Key));
            Assert.That(newCacheKey.Prefixes, Has.Member("testPrefix"));
        }

        [Test]
        public void Create_ShouldReturnNewCacheKeyWithSameKeyAndPrefixes_WhenNoKeyObjectsProvided()
        {
            var cacheKey = new CacheKey("testKey", "testPrefix");
            var newCacheKey = cacheKey.Create(o => o.ToString());

            Assert.That("testKey", Is.EqualTo(newCacheKey.Key));
            Assert.That(newCacheKey.Prefixes, Has.Member("testPrefix"));
        }
    }
}
