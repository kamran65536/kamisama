# ISendEmail

<a id="isendemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs#L7)

Namespace: `KamiSama.ExternalServices.Email.Features`

Kind: `Interface`

## Description

Defines the provider-neutral operation for sending an email message. Implement this contract in a transport package or inject it into application code that sends email.

## Declaration

```csharp
public interface ISendEmail
```

## Example

```csharp
using KamiSama.ExternalServices.Email.Features;

var request = new SendEmailRequest(
    "customer@example.com",
    "Order received",
    "<p>Thank you for your order.</p>",
    IsHtml: true);

await sendEmail.SendEmailAsync(request, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendEmailAsync](method-sendemailasync-15.md) | Sends the supplied email message through the configured provider. Use it with the surrounding package APIs when composing application code. |

