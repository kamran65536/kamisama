# KamiSama.ExternalServices.Sms.Kavenegar

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Scoped Kavenegar SMS provider registration and configuration for KamiSama SMS services. The current sender contains a known inverted validation defect that rejects a configured API key before sending.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Sms.Kavenegar --version 10.0.0
```

Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.

Load `api-key` from a secret store or protected configuration and optionally configure `sender-phone-number`. Select the exact `kavenegar` key in the core defaults section, add both modules, and finish with `Build` or `BuildAsync` so their scoped registrations are applied:

```csharp
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.Kavenegar;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddKavenegarSmsServiceModule(webBuilder.Configuration.GetSection("Sms:Kavenegar"));

var app = await builder.BuildAsync(CancellationToken.None);
```

The provider is scoped and keyed as `kavenegar`; the core package supplies the scoped unkeyed dispatcher used by callers. Never commit the Kavenegar API key or include it in examples, logs, or error messages.

**Known runtime defect:** the internal sender throws `InvalidOperationHttpException` when `KavenegarSmsOptions.IsValid()` returns `true`. A configured API key is rejected before any send, while a missing key continues into provider construction. Successful delivery is not claimed until that condition is corrected. In addition, the Kavenegar SDK call is synchronous, the method returns `Task.CompletedTask`, and the supplied cancellation token is ignored; cancellation cannot stop an in-progress send.

## Namespaces

- [KamiSama.ExternalServices.Sms.Kavenegar](kamisama-externalservices-sms-kavenegar/index.md) (2 types)

## Types

- [KamiSama.ExternalServices.Sms.Kavenegar.ExtendedWebApplicationBuilderExtensions](kamisama-externalservices-sms-kavenegar/kamisama-externalservices-sms-kavenegar-extendedwebapplicationbuilderextensions/index.md) - Adds Kavenegar options binding and the scoped keyed `kavenegar` SMS provider. The current provider has an inverted validation defect and rejects a configured API key before sending.
- [KamiSama.ExternalServices.Sms.Kavenegar.KavenegarSmsOptions](kamisama-externalservices-sms-kavenegar/kamisama-externalservices-sms-kavenegar-kavenegarsmsoptions/index.md) - Contains the Kavenegar sender number and API key. `IsValid` checks for an API key, but the current internal sender incorrectly throws when that check succeeds.
