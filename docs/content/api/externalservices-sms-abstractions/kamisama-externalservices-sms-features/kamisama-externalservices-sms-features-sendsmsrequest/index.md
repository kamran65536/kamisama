# SendSmsRequest

<a id="sendsmsrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs#L8)

Namespace: `KamiSama.ExternalServices.Sms.Features`

Kind: `Record`

## Description

Represents a request to send an SMS message. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record SendSmsRequest(string PhoneNumber, string Message);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs#L8)

Represents a request to send an SMS message. Use it with the surrounding package APIs when composing application code.

```csharp
public record SendSmsRequest(string PhoneNumber, string Message);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `PhoneNumber` | `string` | `-` | Gets or sets the phone number associated with the entity. |
| `Message` | `string` | `-` | Gets or sets the message to be sent via SMS. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

