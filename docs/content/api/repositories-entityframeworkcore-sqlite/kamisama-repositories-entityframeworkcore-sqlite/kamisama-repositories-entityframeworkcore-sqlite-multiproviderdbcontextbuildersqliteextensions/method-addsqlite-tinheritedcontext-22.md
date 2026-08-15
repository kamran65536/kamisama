# AddSqlite<TInheritedContext>

[Back to MultiProviderDbContextBuilderSqliteExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore.Sqlite](../../index.md)

Source: [src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs#L22)

Type: `KamiSama.Repositories.EntityFrameworkCore.Sqlite.MultiProviderDbContextBuilderSqliteExtensions`

Kind: `Method`

## Description

Registers a scoped SQLite context and exposes it under the `sqlite` keyed base-context service. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder AddSqlite<TInheritedContext>(this IMultiProviderDbContextBuilder builder)
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

Enables lazy-loading proxies and uses the configured migration-history table. Configure the provider as exactly `sqlite` (case-insensitive before key lookup). Registrations are scoped.

## Example

```csharp
builder.AddSqlite<SqliteAppDbContext>();
```

