# LocationsModule

<a id="locationsmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/LocationsModule.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/LocationsModule.cs#L12)

Namespace: `KamiSama.Modules.Locations`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `LocationsModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
internal class LocationsModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/LocationsModule.cs#L12)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class LocationsModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `databaseSection` | `IConfigurationSection` | `-` | The `databaseSection` value passed to this member. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<LocationsDbContext>>?` | `null` | The `configureDbContext` value passed to this member. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [ModuleName](field-modulename-17.md) | Stores the `ModuleName` value for `LocationsModule`. Use it where the package exposes this field as part of its API. |

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-31.md) | Runs the `ApplyConfigurationToAsync` operation on `LocationsModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-19.md) | Runs the `ConfigureServices` operation on `LocationsModule`. Use it when your code needs this specific behavior from the package. |

