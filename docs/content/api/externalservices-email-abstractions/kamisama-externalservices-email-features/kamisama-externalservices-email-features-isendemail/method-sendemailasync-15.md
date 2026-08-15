# SendEmailAsync

[Back to ISendEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Abstractions](../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs#L15)

Type: `KamiSama.ExternalServices.Email.Features.ISendEmail`

Kind: `Method`

## Description

Sends the supplied email message through the configured provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `SendEmailRequest` | `-` | The recipient, subject, body, and content format to send. |
| `cancellationToken` | `CancellationToken` | `-` | The token used to cancel the send operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task representing the send operation. |

## Example

No concise standalone example is available yet.

