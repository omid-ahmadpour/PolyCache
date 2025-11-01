# PolyCache — Distributed Cache Manager for .NET (Core)

PolyCache is a lightweight, flexible distributed cache manager for .NET applications. It provides a simple, unified API for caching with multiple backends, helping you boost performance, reduce load on data sources, and simplify cache handling across your app.

- Supported cache providers: Redis, in-memory, and SQL Server
- Simple DI registration
- Centralized, configurable cache times
- Drop-in interface: `IStaticCacheManager`

## Table of Contents
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Configuration](#configuration)
- [Usage](#usage)
- [Setting Up Redis with Docker Compose](#setting-up-redis-with-docker-compose)
- [Notes and Recommendations](#notes-and-recommendations)

## Installation

You can install PolyCache via NuGet.

Package Manager:
```shell
Install-Package PolyCache
```

.NET CLI:
```shell
dotnet add package PolyCache
```

## Quick Start

Register PolyCache in your application's dependency injection container.

ASP.NET Core (Startup.cs):
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddPolyCache(Configuration);
    // ...
}
```

Minimal hosting (Program.cs, .NET 6+):
```csharp
var builder = WebApplication.CreateBuilder(args);

// ...
builder.Services.AddPolyCache(builder.Configuration);
// ...

var app = builder.Build();
app.Run();
```

## Configuration

PolyCache supports multiple providers with a simple configuration model. Add the following sections to your `appsettings.json`:

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

- CacheConfig
  - DefaultCacheTime: Default cache lifetime (minutes) for most entries.
  - ShortTermCacheTime: Shorter cache lifetime (minutes) for volatile entries.
  - BundledFilesCacheTime: Cache lifetime (minutes) for bundled/static resources.

- DistributedCacheConfig
  - DistributedCacheType: One of `redis`, `memory`, or `sqlserver`.
  - Enabled: Set to `true` to enable distributed caching.
  - ConnectionString: Provider-specific connection string (e.g., Redis endpoint).
  - SchemaName (SQL Server only): Database schema for the cache table.
  - TableName (SQL Server only): Table name used to store cache entries.

## Usage

Inject the `IStaticCacheManager` interface wherever you need caching.

```csharp
public class MyService
{
    private readonly IStaticCacheManager _cache;

    public MyService(IStaticCacheManager cache)
    {
        _cache = cache;
    }

    // Use _cache to read/write cache entries, apply lifetimes, etc.
    // See the sample project for concrete examples.
}
```

A sample project demonstrates typical usage patterns, including configuration and integration.

## Setting Up Redis with Docker Compose

If you plan to use Redis as your cache provider, you can spin it up quickly with Docker:

1. Install Docker for your OS.
2. Download `redis-docker-compose.yml` from the sample project.
3. Open a terminal with administrative privileges.
4. Navigate to the folder containing `redis-docker-compose.yml`.
5. Start Redis:
   ```shell
   docker-compose -f redis-docker-compose.yml up -d
   ```
6. Verify it's running:
   ```shell
   docker ps
   ```
7. Update your `appsettings.json` `DistributedCacheConfig.ConnectionString` to point to your Redis instance (e.g., `127.0.0.1:6379,ssl=False`).

## Notes and Recommendations

- For development or single-instance scenarios, `memory` is convenient and fast.
- For multi-instance or production scenarios, `redis` is recommended for true distributed caching.
- When using SQL Server, ensure `SchemaName` and `TableName` are set and that the application has proper permissions.
- Adjust the cache times in `CacheConfig` to match your data volatility and freshness requirements.

Enjoy faster, simpler caching with PolyCache in your .NET applications!
