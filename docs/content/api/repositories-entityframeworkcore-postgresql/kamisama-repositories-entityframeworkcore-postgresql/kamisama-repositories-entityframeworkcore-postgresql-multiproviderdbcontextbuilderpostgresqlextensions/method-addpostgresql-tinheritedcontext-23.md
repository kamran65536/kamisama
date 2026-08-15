# AddPostgresql<TInheritedContext>

[Back to MultiProviderDbContextBuilderPostgresqlExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore.Postgresql](../../index.md)

Source: [src/Repositories.EntityFrameworkCore.Postgresql/MultiProviderDbContextBuilderPostgresqlExtensions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore.Postgresql/MultiProviderDbContextBuilderPostgresqlExtensions.cs#L23)

Type: `KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions`

Kind: `Method`

## Description

Registers a scoped PostgreSQL context and exposes it under the `postgresql` keyed base-context service. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder AddPostgresql<TInheritedContext>(this IMultiProviderDbContextBuilder builder)
    where TInheritedContext : DbContext;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TInheritedContext` | The provider-specific DbContext implementation. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder` | `-` | The builder containing services, connection settings, base context type, and history table. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder` | The same builder, enabling additional provider registrations. |

## Remarks

Enables lazy-loading proxies, uses the configured migration-history table, and sets `Npgsql.EnableLegacyTimestampBehavior` and `Npgsql.DisableDateTimeInfinityConversions` process-wide. Configure the provider as exactly `postgresql` (case-insensitive before key lookup). Registrations are scoped.

## Example

```csharp
builder.AddPostgresql<PostgresqlAppDbContext>();
```

