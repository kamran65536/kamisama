# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs#L26)

Namespace: `KamiSama.ExternalServices.Email.Smtp`

Kind: `Class`

## Description

Adds SMTP options binding and the keyed `smtp` email provider registration to an `ExtendedWebApplicationBuilder`. The current provider has a known inverted validation defect and rejects complete settings before sending.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Example

```csharp
using KamiSama.ExternalServices.Email.Smtp;

builder.AddSmtpEmailServiceModule(
    webBuilder.Configuration.GetSection("Email:Smtp"));
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSmtpEmailServiceModule](method-addsmtpemailservicemodule-34.md) | Binds SMTP settings and registers the keyed `smtp` email provider. Use it with the surrounding package APIs when composing application code. |

