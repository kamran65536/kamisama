# PostgresqlTicketingDbContext

<a id="postgresqlticketingdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Postgresql/Repositories/Database/Postgresql/PostgresqlTicketingDbContext.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Postgresql/Repositories/Database/Postgresql/PostgresqlTicketingDbContext.cs#L11)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Database.Postgresql`

Kind: `Class`

## Description

Concrete PostgreSQL Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlTicketingDbContext` rather than constructing it directly.

## Declaration

```csharp
public class PostgresqlTicketingDbContext(DbContextOptions<PostgresqlTicketingDbContext> options) : TicketingDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(
    ticketingSection, databaseSection,
    database => database.AddPostgresqlTicketingDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Postgresql/Repositories/Database/Postgresql/PostgresqlTicketingDbContext.cs#L11)

Provides the concrete PostgreSQL EF Core context targeted by the Ticketing PostgreSQL migrations. Normal hosts register it through `AddPostgresqlTicketingDbContext` rather than constructing it directly.

```csharp
public class PostgresqlTicketingDbContext(DbContextOptions<PostgresqlTicketingDbContext> options) : TicketingDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PostgresqlTicketingDbContext>` | `-` | The PostgreSQL EF Core options configured from Ticketing database settings. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

