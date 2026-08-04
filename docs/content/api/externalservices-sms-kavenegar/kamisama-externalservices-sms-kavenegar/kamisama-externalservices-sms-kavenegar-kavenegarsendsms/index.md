# KavenegarSendSms

<a id="kavenegarsendsms"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSendSms.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSendSms.cs#L11)

Namespace: `KamiSama.ExternalServices.Sms.Kavenegar`

Kind: `Class`

## Description

Provides the `KavenegarSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class KavenegarSendSms(IOptions<KavenegarSmsOptions> options, ILogger<KavenegarSendSms> logger) : ISendSms
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSendSms.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class KavenegarSendSms(IOptions<KavenegarSmsOptions> options, ILogger<KavenegarSendSms> logger) : ISendSms
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<KavenegarSmsOptions>` | `-` | The `options` value passed to this member. |
| `logger` | `ILogger<KavenegarSendSms>` | `-` | The `logger` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendSmsAsync](method-sendsmsasync-14.md) | Runs the `SendSmsAsync` operation on `KavenegarSendSms`. Use it when your code needs this specific behavior from the package. |

