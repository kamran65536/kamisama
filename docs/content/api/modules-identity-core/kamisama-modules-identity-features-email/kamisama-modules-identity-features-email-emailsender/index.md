# EmailSender

<a id="emailsender"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs#L4)

Namespace: `KamiSama.Modules.Identity.Features.Email`

Kind: `Class`

## Description

Provides the `EmailSender` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class EmailSender(ISendEmail sendEmail) : IEmailSender<ApplicationUser>
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs#L4)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class EmailSender(ISendEmail sendEmail) : IEmailSender<ApplicationUser>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sendEmail` | `ISendEmail` | `-` | The `sendEmail` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendConfirmationLinkAsync](method-sendconfirmationlinkasync-7.md) | Runs the `SendConfirmationLinkAsync` operation on `EmailSender`. Use it when your code needs this specific behavior from the package. |
| [SendPasswordResetCodeAsync](method-sendpasswordresetcodeasync-14.md) | Runs the `SendPasswordResetCodeAsync` operation on `EmailSender`. Use it when your code needs this specific behavior from the package. |
| [SendPasswordResetLinkAsync](method-sendpasswordresetlinkasync-21.md) | Runs the `SendPasswordResetLinkAsync` operation on `EmailSender`. Use it when your code needs this specific behavior from the package. |

