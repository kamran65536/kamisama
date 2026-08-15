# KamiSama.ExternalServices.Email.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral contract and request model for sending email through KamiSama external-service implementations. Reference it from callers and providers that need to exchange recipient, subject, body, and HTML-format data without depending on SMTP or another transport.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Abstractions --version 10.0.0
```

Inject `ISendEmail` into application code and pass a provider-neutral request. Set `IsHtml` only when the body contains HTML:

```csharp
using KamiSama.ExternalServices.Email.Features;

var request = new SendEmailRequest(
    "customer@example.com",
    "Order received",
    "<p>Thank you for your order.</p>",
    IsHtml: true);

await sendEmail.SendEmailAsync(request, cancellationToken);
```

## Namespaces

- [KamiSama.ExternalServices.Email.Features](kamisama-externalservices-email-features/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Email.Features.ISendEmail](kamisama-externalservices-email-features/kamisama-externalservices-email-features-isendemail/index.md) - Defines the provider-neutral operation for sending an email message. Implement this contract in a transport package or inject it into application code that sends email.
- [KamiSama.ExternalServices.Email.Features.SendEmailRequest](kamisama-externalservices-email-features/kamisama-externalservices-email-features-sendemailrequest/index.md) - Contains the provider-neutral data required to send one email message. Use it with `ISendEmail.SendEmailAsync` regardless of the underlying email transport.
