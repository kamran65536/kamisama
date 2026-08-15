# IdentitySqliteDbContextBuilderExtensions

<a id="identitysqlitedbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Sqlite/IdentitySqliteDbContextBuilderExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Sqlite/IdentitySqliteDbContextBuilderExtensions.cs#L9)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

Registers the internal SQLite Identity context under the shared multi-provider infrastructure's `sqlite` key.

## Declaration

```csharp
public static class IdentitySqliteDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqliteIdentityDbContext](method-addsqliteidentitydbcontext-14.md) | Registers the SQLite Identity context under the provider key used by the shared multi-provider infrastructure. Use it with the surrounding package APIs when composing application code. |

