# TicketingSqliteDbContextBuilderExtensions

<a id="ticketingsqlitedbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Sqlite/TicketingSqliteDbContextBuilderExtensions.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/TicketingSqliteDbContextBuilderExtensions.cs#L12)

Namespace: `KamiSama.Modules.Ticketing`

Kind: `Class`

## Description

Registers the SQLite Ticketing context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.

## Declaration

```csharp
public static class TicketingSqliteDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqliteTicketingDbContext](method-addsqliteticketingdbcontext-20.md) | Registers `SqliteTicketingDbContext` and its exact `sqlite` keyed `TicketingDbContext` alias with lazy-loading proxies and the Ticketing migration-history table. |

