# KamiSama.ExternalServices.Email

[Back to KamiSama.ExternalServices.Email.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [EmailCoreServicesModule](kamisama-externalservices-email-emailcoreservicesmodule/index.md) | Class | Registers the default-provider options and scans the core email package for service implementations. Add it when `ISendEmail` should dispatch to the keyed provider selected by configuration. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L14) |
| [EmailDefaultsOptions](kamisama-externalservices-email-emaildefaultsoptions/index.md) | Class | Selects the keyed email provider used by the core dispatcher. The default `mock` provider performs no delivery; set `Email` to a key registered by a transport package for another implementation. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailDefaultsOptions.cs#L9) |
| [ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-email-extendedwebapplicationbuilderextensions/index.md) | Class | Adds core email provider selection and service registrations to an `ExtendedWebApplicationBuilder`. Pass the configuration section that contains the `email` provider key. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L41) |
