# AddTicketingModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs:81](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs#L81)

Type: `KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Queues Ticketing service discovery, keyed context setup, and post-build database initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because three current category-feature registrations are non-assignable.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddTicketingModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder that receives the Ticketing module. |
| `moduleSection` | `IConfigurationSection` | `-` | The Ticketing section whose `initialization` child controls migration and seed stages. |
| `databaseSection` | `IConfigurationSection` | `-` | The section containing the required `provider` and `connection-string` values. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<TicketingDbContext>>?` | `null` | An optional callback that registers installed concrete Ticketing providers. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same extended builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(
    ticketingSection, databaseSection,
    database => database.AddPostgresqlTicketingDbContext());
WebApplication app = await builder.BuildAsync(cancellationToken);
```

