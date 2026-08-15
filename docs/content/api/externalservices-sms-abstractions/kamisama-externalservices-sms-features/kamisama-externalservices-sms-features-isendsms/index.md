# ISendSms

<a id="isendsms"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs#L7)

Namespace: `KamiSama.ExternalServices.Sms.Features`

Kind: `Interface`

## Description

Defines the provider-neutral operation for sending one SMS message. Implement it in a provider package or inject an implementation into application code; this contracts package performs no delivery itself.

## Declaration

```csharp
public interface ISendSms
```

## Example

```csharp
using KamiSama.ExternalServices.Sms.Features;

var request = new SendSmsRequest("+15551234567", "Your code is 123456");
await sendSms.SendSmsAsync(request, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendSmsAsync](method-sendsmsasync-15.md) | Requests that the active provider send one message to the request&apos;s phone number. Use it with the surrounding package APIs when composing application code. |

