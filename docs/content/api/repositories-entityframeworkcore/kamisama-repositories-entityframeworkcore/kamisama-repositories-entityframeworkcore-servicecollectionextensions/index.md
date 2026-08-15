# ServiceCollectionExtensions

<a id="servicecollectionextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs#L11)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Class`

## Description

Binds `provider` and `connection-string`, then adds scoped keyed resolution for an application-facing base context. Concrete provider packages must register the lowercased configured key.

## Declaration

```csharp
public static class ServiceCollectionExtensions
```

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

services.AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"))
    .WithMigrationHistoryTable("__AppMigrationsHistory")
    .AddPostgresql<PostgresqlAppDbContext>()
    .AddSqlite<SqliteAppDbContext>();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddMultiProviderDbContext<TBaseContext>](method-addmultiproviderdbcontext-tbasecontext-25.md) | Binds database settings and adds scoped resolution of a base DbContext through a configured keyed provider. Use it with the surrounding package APIs when composing application code. |

