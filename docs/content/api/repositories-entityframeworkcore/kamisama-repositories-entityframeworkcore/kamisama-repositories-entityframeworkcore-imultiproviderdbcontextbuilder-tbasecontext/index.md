# IMultiProviderDbContextBuilder<TBaseContext>

<a id="imultiproviderdbcontextbuilder-tbasecontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L43)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Interface`

## Description

Carries the services, configuration-selected provider, base context type, and migration-history table used by concrete provider registration extensions.

## Declaration

```csharp
public interface IMultiProviderDbContextBuilder<TBaseContext> : IMultiProviderDbContextBuilder
	where TBaseContext : DbContext
```

## Remarks

Install provider packages and call their generic registration methods with concrete derived contexts.

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

IMultiProviderDbContextBuilder<AppDbContext> contexts = services
    .AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"));
contexts.WithMigrationHistoryTable("__AppMigrationsHistory")
    .AddPostgresql<PostgresqlAppDbContext>();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [WithMigrationHistoryTable](method-withmigrationhistorytable-51.md) | Sets the EF Core migrations history table used by provider registrations. Use it with the surrounding package APIs when composing application code. |

