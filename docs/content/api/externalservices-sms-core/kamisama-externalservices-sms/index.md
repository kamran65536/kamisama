# KamiSama.ExternalServices.Sms

[Back to KamiSama.ExternalServices.Sms.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms-extendedwebapplicationbuilderextensions/index.md) | Class | Adds core SMS provider selection, the unkeyed dispatcher, and the keyed `mock` registration to an `ExtendedWebApplicationBuilder`. Call `Build` or `BuildAsync` to apply the module registrations. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L41) |
| [SmsCoreServicesModule](kamisama-externalservices-sms-smscoreservicesmodule/index.md) | Class | Registers the scoped unkeyed SMS dispatcher, scoped keyed `mock` provider, and default-provider options. Its registrations run when the containing `ExtendedWebApplicationBuilder` is built. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L14) |
| [SmsDefaultsOptions](kamisama-externalservices-sms-smsdefaultsoptions/index.md) | Class | Selects the scoped keyed provider used by the unkeyed SMS dispatcher. The exact keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsDefaultsOptions.cs#L9) |
