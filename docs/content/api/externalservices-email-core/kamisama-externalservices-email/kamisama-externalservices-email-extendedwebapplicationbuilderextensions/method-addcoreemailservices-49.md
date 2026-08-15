# AddCoreEmailServices

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs:49](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L49)

Type: `KamiSama.ExternalServices.Email.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Registers default-provider selection and the core email service implementations. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddCoreEmailServices(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder receiving the module. |
| `defaultsSection` | `IConfigurationSection` | `-` | The configuration section containing the `email` provider key. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder so additional modules can be chained. |

## Example

No concise standalone example is available yet.

