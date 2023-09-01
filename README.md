# PolyCache - Distributed Cache Manager for .Net Core Projects

PolyCache is a powerful distributed cache manager package designed specifically for .Net Core projects. It allows you to efficiently manage and store cached data, enhancing the performance of your applications. If you find PolyCache helpful for your project or learning experience, consider giving it a star ⭐. Your support is appreciated!

## Installation

To get started with PolyCache, you can easily install it via NuGet Package Manager:

```shell
> Install-Package PolyCache
```

## Getting Started

To use PolyCache, you need to register it in your application's Startup class by adding the following code to the `ConfigureServices` method:

```csharp
services.AddPolyCache(Configuration);
```

## Configuration

PolyCache provides various options for configuring your distributed cache. You can choose from the following cache types:

- Redis
- Memory
- SQL Server

### DistributedCacheConfig

#### DistributedCacheType

Select the cache implementation you want to use from the available options.

#### SchemaName (optional)

This setting is only required when using SQL Server as your cache storage.

#### TableName (optional)

Specify the SQL Server database table name where your cache data will be stored.

To configure these options, add the following configuration to your `appsettings.json` file:

```json
"CacheConfig": {
    "DefaultCacheTime": 60,
    "ShortTermCacheTime": 3,
    "BundledFilesCacheTime": 120
},
"DistributedCacheConfig": {
    "DistributedCacheType": "redis",
    "Enabled": true,
    "ConnectionString": "127.0.0.1:6379,ssl=False",
    "SchemaName": "dbo",
    "TableName": "DistributedCache"
}
```

## Usage

Once you've configured PolyCache, you can inject the `IStaticCacheManager` interface into your application and use it to cache data efficiently. A sample project that demonstrates the usage of PolyCache is available in our [GitHub repository](https://github.com/omid-ahmadpour/PolyCache/tree/master/Sample).

## Setting Up Redis with Docker Compose

If you plan to use Redis as your cache storage, follow these steps to set it up with Docker Compose:

1. Install Docker on your operating system.

2. Download the `redis-docker-compose.yml` file from the sample project and place it in a convenient directory on your system.

3. Open your terminal as an administrator.

4. Navigate to the directory where you placed the `redis-docker-compose.yml` file.

5. Run the following command to start Redis in a Docker container:

   ```shell
   docker-compose -f redis-docker-compose.yml up
   ```

6. Redis is now ready to use within your Docker environment.

Enjoy the benefits of PolyCache in your .Net Core projects and optimize your application's performance with ease!
