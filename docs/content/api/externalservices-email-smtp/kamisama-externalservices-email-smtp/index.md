# KamiSama.ExternalServices.Email.Smtp

[Back to KamiSama.ExternalServices.Email.Smtp](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-email-smtp-extendedwebapplicationbuilderextensions/index.md) | Class | Adds SMTP options binding and the keyed `smtp` email provider registration to an `ExtendedWebApplicationBuilder`. The current provider has a known inverted validation defect and rejects complete settings before sending. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs#L26) |
| [SmtpOptions](kamisama-externalservices-email-smtp-smtpoptions/index.md) | Class | Contains SMTP connection, credential, TLS, and sender settings. `IsValid` checks required value presence, but the current internal sender incorrectly throws when that check succeeds. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpOptions.cs#L11) |
