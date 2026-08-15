# IdentityPostgresqlDbContextBuilderExtensions

<a id="identitypostgresqldbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Postgresql/IdentityPostgresqlDbContextBuilderExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Postgresql/IdentityPostgresqlDbContextBuilderExtensions.cs#L9)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

Registers the internal PostgreSQL Identity context under the shared multi-provider infrastructure's `postgresql` key.

## Declaration

```csharp
public static class IdentityPostgresqlDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresqlIdentityDbContext](method-addpostgresqlidentitydbcontext-14.md) | Registers the PostgreSQL Identity context under the provider key used by the shared multi-provider infrastructure. Use it with the surrounding package APIs when composing application code. |

