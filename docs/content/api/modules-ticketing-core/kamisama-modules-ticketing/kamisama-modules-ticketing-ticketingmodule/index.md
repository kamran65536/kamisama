# TicketingModule

<a id="ticketingmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs#L15)

Namespace: `KamiSama.Modules.Ticketing`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `TicketingModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
internal class TicketingModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs#L15)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class TicketingModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `databaseSection` | `IConfigurationSection` | `-` | The `databaseSection` value passed to this member. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<TicketingDbContext>>?` | `null` | The `configureDbContext` value passed to this member. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [ModuleName](field-modulename-20.md) | Stores the `ModuleName` value for `TicketingModule`. Use it where the package exposes this field as part of its API. |

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-33.md) | Runs the `ApplyConfigurationToAsync` operation on `TicketingModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-21.md) | Runs the `ConfigureServices` operation on `TicketingModule`. Use it when your code needs this specific behavior from the package. |

