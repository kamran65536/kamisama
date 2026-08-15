# SendSmsAsync

[Back to ISendSms](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Abstractions](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs#L15)

Type: `KamiSama.ExternalServices.Sms.Features.ISendSms`

Kind: `Method`

## Description

Requests that the active provider send one message to the request&apos;s phone number. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `SendSmsRequest` | `-` | The destination phone number and message text. |
| `cancellationToken` | `CancellationToken` | `-` | The token used to cancel the provider operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes according to the provider implementation. |

## Example

```csharp
using KamiSama.ExternalServices.Sms.Features;

await sendSms.SendSmsAsync(
    new SendSmsRequest("+15551234567", "Your code is 123456"),
    cancellationToken);
```

