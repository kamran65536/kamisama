# AddLocalizationModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:59](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L59)

Type: `KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Reads localization settings immediately, configures supported cultures, and queues request localization before `LocalizationModule`. Provider insertion yields effective precedence of Accept-Language header, query string, then cookie.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddLocalizationModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended builder that receives both localization modules. |
| `moduleSection` | `IConfigurationSection` | `-` | The configuration section containing localization settings. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
webBuilder.Services.AddHttpContextAccessor();
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddLocalizationModule(webBuilder.Configuration.GetSection("Localization"));
```

