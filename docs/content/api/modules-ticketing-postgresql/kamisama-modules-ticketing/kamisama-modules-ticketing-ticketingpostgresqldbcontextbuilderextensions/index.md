# TicketingPostgresqlDbContextBuilderExtensions

<a id="ticketingpostgresqldbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Postgresql/TicketingPostgresqlDbContextBuilderExtensions.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Postgresql/TicketingPostgresqlDbContextBuilderExtensions.cs#L12)

Namespace: `KamiSama.Modules.Ticketing`

Kind: `Class`

## Description

Registers the PostgreSQL Ticketing context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.

## Declaration

```csharp
public static class TicketingPostgresqlDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresqlTicketingDbContext](method-addpostgresqlticketingdbcontext-20.md) | Registers `PostgresqlTicketingDbContext` and its exact `postgresql` keyed `TicketingDbContext` alias with lazy-loading proxies, the Ticketing migration-history table, and shared process-wide Npgsql compatibility switches. |

