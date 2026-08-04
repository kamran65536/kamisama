# NeoSendSms

<a id="neosendsms"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoSendSms.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoSendSms.cs#L11)

Namespace: `KamiSama.ExternalServices.Sms.NeoZarin`

Kind: `Class`

## Description

Provides the `NeoSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class NeoSendSms(IRestBuilder restBuilder, IOptions<NeoZarinSmsOptions> options, ILogger<NeoSendSms> logger) : ISendSms
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoSendSms.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class NeoSendSms(IRestBuilder restBuilder, IOptions<NeoZarinSmsOptions> options, ILogger<NeoSendSms> logger) : ISendSms
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `restBuilder` | `IRestBuilder` | `-` | The `restBuilder` value passed to this member. |
| `options` | `IOptions<NeoZarinSmsOptions>` | `-` | The `options` value passed to this member. |
| `logger` | `ILogger<NeoSendSms>` | `-` | The `logger` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendSmsAsync](method-sendsmsasync-14.md) | Runs the `SendSmsAsync` operation on `NeoSendSms`. Use it when your code needs this specific behavior from the package. |

