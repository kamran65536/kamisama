# MultiProviderDbContextBuilderSqliteExtensions

<a id="multiproviderdbcontextbuildersqliteextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore.Sqlite/MultiProviderDbContextBuilderSqliteExtensions.cs#L9)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Sqlite`

Kind: `Class`

## Description

Registers a scoped SQLite context under the exact `sqlite` key, enables lazy-loading proxies, and configures the provider migration-history table.

## Declaration

```csharp
public static class MultiProviderDbContextBuilderSqliteExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqlite<TInheritedContext>](method-addsqlite-tinheritedcontext-22.md) | Registers a scoped SQLite context and exposes it under the `sqlite` keyed base-context service. Use it with the surrounding package APIs when composing application code. |

