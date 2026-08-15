# SqliteTicketingDbContext

<a id="sqliteticketingdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs#L11)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Concrete SQLite Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteTicketingDbContext` rather than constructing it directly.

## Declaration

```csharp
public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(
    ticketingSection, databaseSection,
    database => database.AddSqliteTicketingDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/Repositories/Database/Sqlite/SqliteTicketingDbContext.cs#L11)

Provides the concrete SQLite EF Core context targeted by the Ticketing SQLite migrations. Normal hosts register it through `AddSqliteTicketingDbContext` rather than constructing it directly.

```csharp
public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqliteTicketingDbContext>` | `-` | The SQLite EF Core options configured from Ticketing database settings. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

