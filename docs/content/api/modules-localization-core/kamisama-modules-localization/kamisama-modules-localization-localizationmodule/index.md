# LocalizationModule

<a id="localizationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L17)

Namespace: `KamiSama.Modules.Localization`

Kind: `Class`

## Description

Registers localization options, resources, and attributed scoped feature implementations. A preceding request-localization module owns middleware configuration.

## Declaration

```csharp
public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
```

## Example

```csharp
var section = webBuilder.Configuration.GetSection("Localization");
var builder = webBuilder.Extend().AddModule(new LocalizationModule(section, "Resources"));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L17)

Registers localization options, resources, and the scoped localization feature implementations discovered in this assembly. Request-culture middleware is added separately by `ExtendedWebApplicationBuilderExtensions.AddLocalizationModule` before this module.

```csharp
public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The configuration section containing `available-cultures` and `default-culture`. |
| `resourcePath` | `string` | `-` | The relative resource path passed to ASP.NET Core localization registration. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-43.md) | Performs no post-build work because the preceding request-localization module applies the middleware. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-23.md) | Scans this assembly for attributed feature services, binds `LocalizationOptions`, supplies a fallback array only when configuration produces , and registers localization resources. Use it with the surrounding package APIs when composing application code. |

