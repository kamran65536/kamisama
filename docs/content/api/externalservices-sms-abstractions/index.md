# KamiSama.ExternalServices.Sms.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral SMS sending contracts and request data. This package contains abstractions only and does not send messages or register an SMS provider.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Sms.Abstractions --version 10.0.0
```

Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available:

```csharp
using KamiSama.ExternalServices.Sms.Features;

var request = new SendSmsRequest("+15551234567", "Your code is 123456");
await sendSms.SendSmsAsync(request, cancellationToken);
```

This package defines contracts only. It does not register a provider, select one, or send an SMS; the injected `ISendSms` implementation determines delivery and error behavior.

## Namespaces

- [KamiSama.ExternalServices.Sms.Features](kamisama-externalservices-sms-features/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Sms.Features.ISendSms](kamisama-externalservices-sms-features/kamisama-externalservices-sms-features-isendsms/index.md) - Defines the provider-neutral operation for sending one SMS message. Implement it in a provider package or inject an implementation into application code; this contracts package performs no delivery itself.
- [KamiSama.ExternalServices.Sms.Features.SendSmsRequest](kamisama-externalservices-sms-features/kamisama-externalservices-sms-features-sendsmsrequest/index.md) - Contains the destination phone number and text for one provider-neutral SMS request. Pass it to `ISendSms.SendSmsAsync`; an external implementation determines delivery behavior.
