# SqliteTicketingDbContext

<a id="sqliteticketingdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs#L6)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Provides the `SqliteTicketingDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqliteTicketingDbContext>` | `-` | The `options` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

