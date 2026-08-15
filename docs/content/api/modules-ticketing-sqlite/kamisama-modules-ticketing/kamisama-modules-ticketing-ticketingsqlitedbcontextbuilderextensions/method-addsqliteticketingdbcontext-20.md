# AddSqliteTicketingDbContext

[Back to TicketingSqliteDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Sqlite](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Sqlite/TicketingSqliteDbContextBuilderExtensions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Sqlite/TicketingSqliteDbContextBuilderExtensions.cs#L20)

Type: `KamiSama.Modules.Ticketing.TicketingSqliteDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `SqliteTicketingDbContext` and its exact `sqlite` keyed `TicketingDbContext` alias with lazy-loading proxies and the Ticketing migration-history table.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<TicketingDbContext> AddSqliteTicketingDbContext(this IMultiProviderDbContextBuilder<TicketingDbContext> builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder<TicketingDbContext>` | `-` | The provider-neutral Ticketing context builder created by Core. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<TicketingDbContext>` | The same builder for additional provider registrations. |

## Example

```csharp
database.AddSqliteTicketingDbContext(); // Registers the exact sqlite provider key.
```

