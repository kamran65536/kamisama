# KamiSama.ExternalServices.Email.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Core email service registrations and shared email behavior. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.ExternalServices.Email.Core --version 10.0.10
```

## Namespaces

- [KamiSama.ExternalServices.Email](kamisama-externalservices-email/index.md) (3 types)
- [KamiSama.ExternalServices.Email.Features](kamisama-externalservices-email-features/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Email.EmailCoreServicesModule](kamisama-externalservices-email/kamisama-externalservices-email-emailcoreservicesmodule/index.md) - ASP.NET Core web-module implementation for `EmailCoreServicesModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.
- [KamiSama.ExternalServices.Email.EmailDefaultsOptions](kamisama-externalservices-email/kamisama-externalservices-email-emaildefaultsoptions/index.md) - Configuration object for `EmailDefaultsOptions`. Use it when binding settings or configuring the related package services.
- [KamiSama.ExternalServices.Email.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-email/kamisama-externalservices-email-extendedwebapplicationbuilderextensions/index.md) - Provides the `ExtendedWebApplicationBuilderExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.ExternalServices.Email.Features.DefaultSendEmail](kamisama-externalservices-email-features/kamisama-externalservices-email-features-defaultsendemail/index.md) - Provides the `DefaultSendEmail` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.ExternalServices.Email.Features.MockSendEmail](kamisama-externalservices-email-features/kamisama-externalservices-email-features-mocksendemail/index.md) - Provides the `MockSendEmail` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
