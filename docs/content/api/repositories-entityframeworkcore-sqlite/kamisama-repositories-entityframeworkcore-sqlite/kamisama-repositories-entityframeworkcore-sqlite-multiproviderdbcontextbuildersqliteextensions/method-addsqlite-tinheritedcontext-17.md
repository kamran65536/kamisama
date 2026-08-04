# AddSqlite<TInheritedContext>

[Back to MultiProviderDbContextBuilderSqliteExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore.Sqlite](../../index.md)

Source: [src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs#L17)

Type: `KamiSama.Repositories.EntityFrameworkCore.Sqlite.MultiProviderDbContextBuilderSqliteExtensions`

Kind: `Method`

## Description

Registers a SQLite DbContext implementation for the builder base context. Use it with the surrounding package APIs when composing application code.

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
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder` | `-` | The multi-provider DbContext builder. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder` | The current builder. |

## Example

No concise standalone example is available yet.

