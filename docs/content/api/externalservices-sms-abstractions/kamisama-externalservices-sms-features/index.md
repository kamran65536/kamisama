# KamiSama.ExternalServices.Sms.Features

[Back to KamiSama.ExternalServices.Sms.Abstractions](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ISendSms](kamisama-externalservices-sms-features-isendsms/index.md) | Interface | Defines the provider-neutral operation for sending one SMS message. Implement it in a provider package or inject an implementation into application code; this contracts package performs no delivery itself. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Features.cs#L7) |
| [SendSmsRequest](kamisama-externalservices-sms-features-sendsmsrequest/index.md) | Record | Contains the destination phone number and text for one provider-neutral SMS request. Pass it to `ISendSms.SendSmsAsync`; an external implementation determines delivery behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Abstractions/Features/Dtos.cs#L9) |
