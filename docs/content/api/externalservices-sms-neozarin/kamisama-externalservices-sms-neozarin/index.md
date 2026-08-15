# KamiSama.ExternalServices.Sms.NeoZarin

[Back to KamiSama.ExternalServices.Sms.NeoZarin](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms-neozarin-extendedwebapplicationbuilderextensions/index.md) | Class | Adds NeoZarin options binding and the scoped keyed `neo-zarin` SMS provider. Register `HttpClient` and KamiSama RestSharp first; the current provider also has an inverted validation defect. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs#L33) |
| [NeoZarinSmsOptions](kamisama-externalservices-sms-neozarin-neozarinsmsoptions/index.md) | Class | Contains NeoZarin endpoint, credential, sender, and API settings. `IsValidForSms` checks required value presence, but the current internal sender incorrectly throws when that check succeeds. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsOptions.cs#L11) |
