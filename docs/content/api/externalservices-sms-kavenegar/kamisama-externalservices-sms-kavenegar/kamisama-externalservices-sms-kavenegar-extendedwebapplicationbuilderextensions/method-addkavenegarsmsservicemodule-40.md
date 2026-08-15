# AddKavenegarSmsServiceModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs#L40)

Type: `KamiSama.ExternalServices.Sms.Kavenegar.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Adds the Kavenegar SMS module; its services are registered when `Build` or `BuildAsync` is called on the extended builder. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddKavenegarSmsServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection kavenegarSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder receiving the module. |
| `kavenegarSection` | `IConfigurationSection` | `-` | The configuration section containing `sender-phone-number` and the secret `api-key`. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder so core SMS and application modules can be chained. |

## Example

No concise standalone example is available yet.

