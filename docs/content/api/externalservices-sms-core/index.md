# KamiSama.ExternalServices.Sms.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Core SMS service registrations and shared SMS behavior. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.ExternalServices.Sms.Core --version 10.0.10
```

## Namespaces

- [KamiSama.ExternalServices.Sms](kamisama-externalservices-sms/index.md) (3 types)
- [KamiSama.ExternalServices.Sms.Features](kamisama-externalservices-sms-features/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Sms.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms/kamisama-externalservices-sms-extendedwebapplicationbuilderextensions/index.md) - Provides the `ExtendedWebApplicationBuilderExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.ExternalServices.Sms.SmsCoreServicesModule](kamisama-externalservices-sms/kamisama-externalservices-sms-smscoreservicesmodule/index.md) - ASP.NET Core web-module implementation for `SmsCoreServicesModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.
- [KamiSama.ExternalServices.Sms.SmsDefaultsOptions](kamisama-externalservices-sms/kamisama-externalservices-sms-smsdefaultsoptions/index.md) - Configuration object for `SmsDefaultsOptions`. Use it when binding settings or configuring the related package services.
- [KamiSama.ExternalServices.Sms.Features.DefaultSendSms](kamisama-externalservices-sms-features/kamisama-externalservices-sms-features-defaultsendsms/index.md) - Provides the `DefaultSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.ExternalServices.Sms.Features.MockSendSms](kamisama-externalservices-sms-features/kamisama-externalservices-sms-features-mocksendsms/index.md) - Provides the `MockSendSms` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
