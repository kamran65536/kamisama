# AddSmtpEmailServiceModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs#L34)

Type: `KamiSama.ExternalServices.Email.Smtp.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Binds SMTP settings and registers the keyed `smtp` email provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddSmtpEmailServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection smtpServiceSection);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder receiving the module. |
| `smtpServiceSection` | `IConfigurationSection` | `-` | The configuration section containing SMTP connection and sender settings. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder so additional modules can be chained. |

## Example

No concise standalone example is available yet.

