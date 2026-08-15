# KamiSama.ExternalServices.Email.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-selecting email registration for ASP.NET Core applications, including default-provider options and a built-in mock provider. Use it to route `ISendEmail` calls to keyed transport implementations.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Email.Core --version 10.0.0
```

Add the core module with a configuration section whose `email` value names the keyed provider. The built-in `mock` provider only logs method entry; add a transport package and use its key for real delivery:

```csharp
using KamiSama.ExternalServices.Email;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddCoreEmailServices(webBuilder.Configuration.GetSection("EmailDefaults"));

var app = await builder.BuildAsync(CancellationToken.None);
```

Configure `EmailDefaults:email` as `mock` for the built-in no-delivery implementation or as the key registered by an installed provider. If no keyed `ISendEmail` exists for that value, the dispatcher throws `CannotFindExternalServiceException`.

## Namespaces

- [KamiSama.ExternalServices.Email](kamisama-externalservices-email/index.md) (3 types)

## Types

- [KamiSama.ExternalServices.Email.EmailCoreServicesModule](kamisama-externalservices-email/kamisama-externalservices-email-emailcoreservicesmodule/index.md) - Registers the default-provider options and scans the core email package for service implementations. Add it when `ISendEmail` should dispatch to the keyed provider selected by configuration.
- [KamiSama.ExternalServices.Email.EmailDefaultsOptions](kamisama-externalservices-email/kamisama-externalservices-email-emaildefaultsoptions/index.md) - Selects the keyed email provider used by the core dispatcher. The default `mock` provider performs no delivery; set `Email` to a key registered by a transport package for another implementation.
- [KamiSama.ExternalServices.Email.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-email/kamisama-externalservices-email-extendedwebapplicationbuilderextensions/index.md) - Adds core email provider selection and service registrations to an `ExtendedWebApplicationBuilder`. Pass the configuration section that contains the `email` provider key.
