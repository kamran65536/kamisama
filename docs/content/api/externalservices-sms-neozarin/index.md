# KamiSama.ExternalServices.Sms.NeoZarin

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Scoped NeoZarin HTTP SMS provider registration and configuration for KamiSama SMS services. It requires KamiSama RestSharp and `AddHttpClient`, and the current sender contains a known inverted validation defect.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Sms.NeoZarin --version 10.0.0
```

Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.

Register `HttpClient` and KamiSama RestSharp before adding the SMS modules. Select the exact `neo-zarin` key in core defaults and bind `base-url`, `username`, `password`, `sms-api-path`, `sms-sender-number`, and `sms-api-key` from protected configuration:

```csharp
using KamiSama.Extensions.RestSharp;
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.NeoZarin;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddHttpClient();
webBuilder.Services.AddKamiSamaRestSharp();

var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddNeoZarinSmsModule(webBuilder.Configuration.GetSection("Sms:NeoZarin"));

var app = await builder.BuildAsync(CancellationToken.None);
```

The provider is scoped and keyed as `neo-zarin`; the core package supplies the scoped unkeyed dispatcher. Store the username, password, and SMS API key in a secret provider, never source control. The default base URL is plain HTTP, so configure an HTTPS provider endpoint when available. If request execution is reached, the cancellation token is forwarded to RestSharp.

**Known runtime defect:** the internal sender throws `InvalidOperationHttpException` when `NeoZarinSmsOptions.IsValidForSms()` returns `true`. Complete settings are rejected before any HTTP request, while incomplete settings continue toward request construction. Successful delivery is not claimed until that condition is corrected.

## Namespaces

- [KamiSama.ExternalServices.Sms.NeoZarin](kamisama-externalservices-sms-neozarin/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Sms.NeoZarin.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms-neozarin/kamisama-externalservices-sms-neozarin-extendedwebapplicationbuilderextensions/index.md) - Adds NeoZarin options binding and the scoped keyed `neo-zarin` SMS provider. Register `HttpClient` and KamiSama RestSharp first; the current provider also has an inverted validation defect.
- [KamiSama.ExternalServices.Sms.NeoZarin.NeoZarinSmsOptions](kamisama-externalservices-sms-neozarin/kamisama-externalservices-sms-neozarin-neozarinsmsoptions/index.md) - Contains NeoZarin endpoint, credential, sender, and API settings. `IsValidForSms` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.
