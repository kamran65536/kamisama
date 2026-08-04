# AddLocationsModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/LocationsModule.cs:47](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/LocationsModule.cs#L47)

Type: `KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Runs the `AddLocationsModule` operation on `ExtendedWebApplicationBuilderExtensions`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddLocationsModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `databaseSection` | `IConfigurationSection` | `-` | The `databaseSection` value passed to this member. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<LocationsDbContext>>?` | `null` | The `configureDbContext` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

