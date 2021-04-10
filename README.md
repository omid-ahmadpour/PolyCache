# PolyCache
Redis Cache NuGet package

## Give a Star! ⭐
If you like or are using this package or start your solution, please give it a star. Thanks!

## Installing PolyCache

```ruby
> Install-Package PolyCache
```

## Registering PolyCache
### in Startup -> ConfigureServices

```ruby
> services.AddPolyCache(Configuration);
```

# DistributedCacheConfig

## DistributedCacheType You can choose one of the implementations:
###  Memory
###  SQL Server
###  Redis

## SchemaName (optional)
#### This setting is only used in conjunction with SQL Server.

## TableName (optional)
#### This setting is only used in conjunction with SQL Server. SQL Server database name.

## Put the following configuration in appsettings.json.
```
CacheConfig": {
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
  
  ### The source of a project that used PolyCache is also included.

> [Sample For Use PolyCache](https://github.com/omid-ahmadpour/PolyCache/tree/master/Sample)
