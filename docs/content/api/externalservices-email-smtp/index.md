# KamiSama.ExternalServices.Email.Smtp

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SMTP transport registration and configuration for KamiSama email services. The current implementation contains a known inverted validation defect that rejects complete SMTP settings before sending.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Smtp --version 10.0.0
```

Add the SMTP module with the section that contains `host`, `port`, `username`, `password`, `use-ssl`, `sender-address`, and `sender-name`:

```csharp
using KamiSama.ExternalServices.Email.Smtp;

builder.AddSmtpEmailServiceModule(
    webBuilder.Configuration.GetSection("Email:Smtp"));
```

**Known runtime defect:** the internal SMTP sender currently throws `InvalidOperationHttpException` when `SmtpOptions.IsValid()` returns `true`. Complete settings are therefore rejected before any SMTP send is attempted, while incomplete settings continue and fail later. This documentation does not claim successful delivery; the runtime condition must be corrected in a future code change before relying on this provider.

## Namespaces

- [KamiSama.ExternalServices.Email.Smtp](kamisama-externalservices-email-smtp/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Email.Smtp.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-email-smtp/kamisama-externalservices-email-smtp-extendedwebapplicationbuilderextensions/index.md) - Adds SMTP options binding and the keyed `smtp` email provider registration to an `ExtendedWebApplicationBuilder`. The current provider has a known inverted validation defect and rejects complete settings before sending.
- [KamiSama.ExternalServices.Email.Smtp.SmtpOptions](kamisama-externalservices-email-smtp/kamisama-externalservices-email-smtp-smtpoptions/index.md) - Contains SMTP connection, credential, TLS, and sender settings. `IsValid` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.
