# KamiSama.ExternalServices.Email.Abstractions

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Email service DTOs and feature contracts. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.ExternalServices.Email.Abstractions --version 10.0.10
```

## Namespaces

- [KamiSama.ExternalServices.Email.Features](kamisama-externalservices-email-features/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Email.Features.ISendEmail](kamisama-externalservices-email-features/kamisama-externalservices-email-features-isendemail/index.md) - Defines the contract for `ISendEmail` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.ExternalServices.Email.Features.SendEmailRequest](kamisama-externalservices-email-features/kamisama-externalservices-email-features-sendemailrequest/index.md) - Provides the `SendEmailRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
