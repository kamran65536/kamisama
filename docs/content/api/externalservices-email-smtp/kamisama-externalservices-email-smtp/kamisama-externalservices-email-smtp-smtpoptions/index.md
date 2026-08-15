# SmtpOptions

<a id="smtpoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpOptions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpOptions.cs#L11)

Namespace: `KamiSama.ExternalServices.Email.Smtp`

Kind: `Class`

## Description

Contains SMTP connection, credential, TLS, and sender settings. `IsValid` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.

## Declaration

```csharp
public class SmtpOptions
```

## Remarks

The current SMTP sender has a known inverted validation check: settings for which `IsValid` returns are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.

## Example

```csharp
using KamiSama.ExternalServices.Email.Smtp;

var options = new SmtpOptions
{
    Host = "smtp.example.com",
    Port = 587,
    Username = "smtp-user",
    Password = smtpPassword,
    UseSsl = true,
    SenderAddress = "noreply@example.com",
    SenderAddressName = "Example App"
};

bool valuesArePresent = options.IsValid();
// Known defect: the current internal sender throws when this value is true.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [IsValid](method-isvalid-40.md) | Returns when all required string settings are non-null and `Port` is nonzero. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Host](property-host-14.md) | Gets or sets the SMTP server host name. Use it with the surrounding package APIs when composing application code. |
| [Password](property-password-23.md) | Gets or sets the password used to authenticate with the SMTP server. Use it with the surrounding package APIs when composing application code. |
| [Port](property-port-17.md) | Gets or sets the SMTP server port. A value of zero is considered invalid by `IsValid`. |
| [SenderAddress](property-senderaddress-29.md) | Gets or sets the email address placed in the message&apos;s From header. Use it with the surrounding package APIs when composing application code. |
| [SenderAddressName](property-senderaddressname-32.md) | Gets or sets the display name placed in the message&apos;s From header. Use it with the surrounding package APIs when composing application code. |
| [Username](property-username-20.md) | Gets or sets the user name used to authenticate with the SMTP server. Use it with the surrounding package APIs when composing application code. |
| [UseSsl](property-usessl-26.md) | Gets or sets whether the SMTP client enables SSL. Use it with the surrounding package APIs when composing application code. |

