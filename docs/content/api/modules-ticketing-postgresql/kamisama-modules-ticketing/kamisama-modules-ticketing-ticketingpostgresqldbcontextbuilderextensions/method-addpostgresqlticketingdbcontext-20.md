# AddPostgresqlTicketingDbContext

[Back to TicketingPostgresqlDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Postgresql](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Postgresql/TicketingPostgresqlDbContextBuilderExtensions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Postgresql/TicketingPostgresqlDbContextBuilderExtensions.cs#L20)

Type: `KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `PostgresqlTicketingDbContext` and its exact `postgresql` keyed `TicketingDbContext` alias with lazy-loading proxies, the Ticketing migration-history table, and shared process-wide Npgsql compatibility switches.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<TicketingDbContext> AddPostgresqlTicketingDbContext(this IMultiProviderDbContextBuilder<TicketingDbContext> builder);
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
database.AddPostgresqlTicketingDbContext(); // Registers the exact postgresql provider key.
```

