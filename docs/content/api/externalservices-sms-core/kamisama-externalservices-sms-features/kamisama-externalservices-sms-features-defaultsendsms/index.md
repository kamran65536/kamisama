# DefaultSendSms

<a id="defaultsendsms"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/Features/DefaultSendSms.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/Features/DefaultSendSms.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms.Features`

Kind: `Class`

## Description

Provides the `DefaultSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class DefaultSendSms(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<SmsDefaultsOptions> options) : ISendSms
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/Features/DefaultSendSms.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class DefaultSendSms(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<SmsDefaultsOptions> options) : ISendSms
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `loggerFactory` | `ILoggerFactory` | `-` | The `loggerFactory` value passed to this member. |
| `serviceProvider` | `IServiceProvider` | `-` | The `serviceProvider` value passed to this member. |
| `options` | `IOptions<SmsDefaultsOptions>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SendSmsAsync](method-sendsmsasync-12.md) | Runs the `SendSmsAsync` operation on `DefaultSendSms`. Use it when your code needs this specific behavior from the package. |

