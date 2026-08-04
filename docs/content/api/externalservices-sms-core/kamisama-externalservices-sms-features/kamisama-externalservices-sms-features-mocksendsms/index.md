# MockSendSms

<a id="mocksendsms"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/Features/MockSendSms.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/Features/MockSendSms.cs#L7)

Namespace: `KamiSama.ExternalServices.Sms.Features`

Kind: `Class`

## Description

Provides the `MockSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class MockSendSms(ILogger<MockSendSms> logger) : ISendSms
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/Features/MockSendSms.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class MockSendSms(ILogger<MockSendSms> logger) : ISendSms
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `logger` | `ILogger<MockSendSms>` | `-` | The `logger` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendSmsAsync](method-sendsmsasync-10.md) | Runs the `SendSmsAsync` operation on `MockSendSms`. Use it when your code needs this specific behavior from the package. |

