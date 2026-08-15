# KamiSama.ExternalServices.Sms.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-selecting SMS registration for ASP.NET Core applications, including default-provider options and a scoped mock provider. Use it to route unkeyed `ISendSms` calls to scoped keyed providers.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Sms.Core --version 10.0.0
```

Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.

Add the core module with a configuration section whose `sms` value is exactly `mock`, `kavenegar`, or `neo-zarin`. Add the selected provider module, then build through the extended builder; merely calling an `Add*Module` method does not run module service registration:

```csharp
using KamiSama.ExternalServices.Sms;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"));

var app = await builder.BuildAsync(CancellationToken.None);
```

The core module registers a scoped unkeyed `ISendSms` dispatcher and the scoped keyed `mock` implementation. Provider packages register scoped keyed implementations under `kavenegar` and `neo-zarin`; application code normally injects unkeyed `ISendSms`. The mock logs method entry and does not deliver a message.

**Runtime caveats:** an unknown configured key actually fails in `GetRequiredKeyedService` with `InvalidOperationException`; the following null check and `CannotFindExternalServiceException` are not reached. The dispatcher returns the provider task without awaiting it, so only exceptions thrown synchronously while invoking the provider are wrapped as `InvalidResponseForExternalServiceException`; exceptions faulting the returned task are not logged or wrapped. `HttpExceptionBase` exceptions and cancellation behavior remain provider-specific.

## Namespaces

- [KamiSama.ExternalServices.Sms](kamisama-externalservices-sms/index.md) (3 types)

## Types

- [KamiSama.ExternalServices.Sms.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms/kamisama-externalservices-sms-extendedwebapplicationbuilderextensions/index.md) - Adds core SMS provider selection, the unkeyed dispatcher, and the keyed `mock` registration to an `ExtendedWebApplicationBuilder`. Call `Build` or `BuildAsync` to apply the module registrations.
- [KamiSama.ExternalServices.Sms.SmsCoreServicesModule](kamisama-externalservices-sms/kamisama-externalservices-sms-smscoreservicesmodule/index.md) - Registers the scoped unkeyed SMS dispatcher, scoped keyed `mock` provider, and default-provider options. Its registrations run when the containing `ExtendedWebApplicationBuilder` is built.
- [KamiSama.ExternalServices.Sms.SmsDefaultsOptions](kamisama-externalservices-sms/kamisama-externalservices-sms-smsdefaultsoptions/index.md) - Selects the scoped keyed provider used by the unkeyed SMS dispatcher. The exact keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`.
