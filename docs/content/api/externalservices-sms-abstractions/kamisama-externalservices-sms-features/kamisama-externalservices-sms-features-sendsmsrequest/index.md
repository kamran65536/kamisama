# SendSmsRequest

<a id="sendsmsrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms.Features`

Kind: `Record`

## Description

Contains the destination phone number and text for one provider-neutral SMS request. Pass it to `ISendSms.SendSmsAsync`; an external implementation determines delivery behavior.

## Declaration

```csharp
public record SendSmsRequest(string PhoneNumber, string Message);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs#L9)

Contains the provider-neutral destination and message text for one SMS request. Pass it to `ISendSms.SendSmsAsync`; delivery behavior belongs to the selected provider implementation.

```csharp
public record SendSmsRequest(string PhoneNumber, string Message);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `PhoneNumber` | `string` | `-` | The destination phone number in the format expected by the provider. |
| `Message` | `string` | `-` | The text to send. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

