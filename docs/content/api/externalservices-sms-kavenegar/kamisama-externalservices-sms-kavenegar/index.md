# KamiSama.ExternalServices.Sms.Kavenegar

[Back to KamiSama.ExternalServices.Sms.Kavenegar](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms-kavenegar-extendedwebapplicationbuilderextensions/index.md) | Class | Adds Kavenegar options binding and the scoped keyed `kavenegar` SMS provider. The current provider has an inverted validation defect and rejects a configured API key before sending. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs#L32) |
| [KavenegarSmsOptions](kamisama-externalservices-sms-kavenegar-kavenegarsmsoptions/index.md) | Class | Contains the Kavenegar sender number and API key. `IsValid` checks for an API key, but the current internal sender incorrectly throws when that check succeeds. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSmsOptions.cs#L11) |
