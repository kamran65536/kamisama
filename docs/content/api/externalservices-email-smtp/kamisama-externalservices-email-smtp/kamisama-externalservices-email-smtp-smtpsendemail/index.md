# SmtpSendEmail

<a id="smtpsendemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpSendEmail.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpSendEmail.cs#L12)

Namespace: `KamiSama.ExternalServices.Email.Smtp`

Kind: `Class`

## Description

Provides the `SmtpSendEmail` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class SmtpSendEmail(IOptions<SmtpOptions> options, ILogger<SmtpSendEmail> logger) : ISendEmail
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpSendEmail.cs#L12)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class SmtpSendEmail(IOptions<SmtpOptions> options, ILogger<SmtpSendEmail> logger) : ISendEmail
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<SmtpOptions>` | `-` | The `options` value passed to this member. |
| `logger` | `ILogger<SmtpSendEmail>` | `-` | The `logger` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendEmailAsync](method-sendemailasync-15.md) | Runs the `SendEmailAsync` operation on `SmtpSendEmail`. Use it when your code needs this specific behavior from the package. |

