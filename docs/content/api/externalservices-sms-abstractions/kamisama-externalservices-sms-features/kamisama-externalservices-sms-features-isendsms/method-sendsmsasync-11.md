# SendSmsAsync

[Back to ISendSms](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Abstractions](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs#L11)

Type: `KamiSama.ExternalServices.Sms.Features.ISendSms`

Kind: `Method`

## Description

Sends an SMS message to the specified phone number. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `SendSmsRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

