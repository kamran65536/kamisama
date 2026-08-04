# PostgresqlKamiSamaIdentityDbContext

<a id="postgresqlkamisamaidentitydbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Postgresql/Repositories/Database/Postgresql/PostgresqlKamiSamaIdentityDbContext.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Postgresql/Repositories/Database/Postgresql/PostgresqlKamiSamaIdentityDbContext.cs#L5)

Namespace: `KamiSama.Modules.Identity.Repositories.Database.Postgresql`

Kind: `Class`

## Description

Provides the `PostgresqlKamiSamaIdentityDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class PostgresqlKamiSamaIdentityDbContext(DbContextOptions<PostgresqlKamiSamaIdentityDbContext> options) : KamiSamaIdentityDbContext(options)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Postgresql/Repositories/Database/Postgresql/PostgresqlKamiSamaIdentityDbContext.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class PostgresqlKamiSamaIdentityDbContext(DbContextOptions<PostgresqlKamiSamaIdentityDbContext> options) : KamiSamaIdentityDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PostgresqlKamiSamaIdentityDbContext>` | `-` | The `options` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

