# SqliteKamiSamaIdentityDbContext

<a id="sqlitekamisamaidentitydbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Sqlite/Repositories/Database/Sqlite/SqliteKamiSamaIdentityDbContext.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Sqlite/Repositories/Database/Sqlite/SqliteKamiSamaIdentityDbContext.cs#L5)

Namespace: `KamiSama.Modules.Identity.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Provides the `SqliteKamiSamaIdentityDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class SqliteKamiSamaIdentityDbContext(DbContextOptions<SqliteKamiSamaIdentityDbContext> options) 
	: KamiSamaIdentityDbContext(options)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Sqlite/Repositories/Database/Sqlite/SqliteKamiSamaIdentityDbContext.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class SqliteKamiSamaIdentityDbContext(DbContextOptions<SqliteKamiSamaIdentityDbContext> options) 
	: KamiSamaIdentityDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqliteKamiSamaIdentityDbContext>` | `-` | The `options` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

