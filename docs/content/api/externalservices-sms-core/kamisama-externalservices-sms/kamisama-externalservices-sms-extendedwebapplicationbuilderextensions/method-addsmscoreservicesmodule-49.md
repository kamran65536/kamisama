# AddSmsCoreServicesModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs:49](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L49)

Type: `KamiSama.ExternalServices.Sms.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Adds the core SMS module; its services are registered when `Build` or `BuildAsync` is called on the extended builder. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddSmsCoreServicesModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder receiving the module. |
| `defaultsSection` | `IConfigurationSection` | `-` | The configuration section containing the `sms` provider key. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder so provider and application modules can be chained. |

## Example

No concise standalone example is available yet.

