# KamiSama.ExternalServices.Email.Features

[Back to KamiSama.ExternalServices.Email.Abstractions](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ISendEmail](kamisama-externalservices-email-features-isendemail/index.md) | Interface | Defines the provider-neutral operation for sending an email message. Implement this contract in a transport package or inject it into application code that sends email. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Features.cs#L7) |
| [SendEmailRequest](kamisama-externalservices-email-features-sendemailrequest/index.md) | Record | Contains the provider-neutral data required to send one email message. Use it with `ISendEmail.SendEmailAsync` regardless of the underlying email transport. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Abstractions/Features/Dtos.cs#L11) |
