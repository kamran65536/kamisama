# MultiProviderDbContextBuilderPostgresqlExtensions

<a id="multiproviderdbcontextbuilderpostgresqlextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore.Postgresql/MultiProviderDbContextBuilderPostgresqlExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore.Postgresql/MultiProviderDbContextBuilderPostgresqlExtensions.cs#L9)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Postgresql`

Kind: `Class`

## Description

Registers a scoped PostgreSQL context under the exact `postgresql` key, enables lazy-loading proxies, configures migration history, and sets two process-wide Npgsql compatibility switches.

## Declaration

```csharp
public static class MultiProviderDbContextBuilderPostgresqlExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresql<TInheritedContext>](method-addpostgresql-tinheritedcontext-23.md) | Registers a scoped PostgreSQL context and exposes it under the `postgresql` keyed base-context service. Use it with the surrounding package APIs when composing application code. |

