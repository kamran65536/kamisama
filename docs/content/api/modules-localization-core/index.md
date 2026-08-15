# KamiSama.Modules.Localization.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core localization registration and scoped features for configured culture discovery, current-culture lookup, and culture-selection cookies. Use it to bind localization settings and compose request localization through `KamiSama.Modules`.

## How to use

```shell
dotnet add package KamiSama.Modules.Localization.Core --version 10.0.0
```

Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.

Register `IHttpContextAccessor` before adding the localization module, bind the module section, and build through the extended builder:

```csharp
using KamiSama.Modules;
using KamiSama.Modules.Localization;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddHttpContextAccessor();

var builder = webBuilder.Extend()
    .AddLocalizationModule(webBuilder.Configuration.GetSection("Localization"));

var app = await builder.BuildAsync(CancellationToken.None);
```

The effective request provider precedence is Accept-Language header, then query string, then cookie because each provider is inserted at the front. `SetCulture.SetAsync` validates configured metadata and appends a one-year response cookie; it does not change the current request, so the cookie participates on a later request and still loses to header or query values. The three feature methods complete synchronously and ignore cancellation. `ListAvailableCultures.ListAsync` exposes the mutable configured array directly, and options also accept mutable replacement arrays. `GetCurrentCulture` falls back only when the current UI culture is neutral and synthesizes metadata when no configured entry matches.

## Namespaces

- [KamiSama.Modules.Localization](kamisama-modules-localization/index.md) (3 types)
- [KamiSama.Modules.Localization.Features](kamisama-modules-localization-features/index.md) (3 types)

## Types

- [KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions](kamisama-modules-localization/kamisama-modules-localization-extendedwebapplicationbuilderextensions/index.md) - Adds request localization and the localization core module in the required order. Provider insertion produces Accept-Language, query-string, then cookie precedence.
- [KamiSama.Modules.Localization.LocalizationModule](kamisama-modules-localization/kamisama-modules-localization-localizationmodule/index.md) - Registers localization options, resources, and attributed scoped feature implementations. A preceding request-localization module owns middleware configuration.
- [KamiSama.Modules.Localization.LocalizationOptions](kamisama-modules-localization/kamisama-modules-localization-localizationoptions/index.md) - Holds mutable supported-culture metadata and the default culture name bound from configuration. Culture arrays are exposed directly rather than copied.
- [KamiSama.Modules.Localization.Features.GetCurrentCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-getcurrentculture/index.md) - Maps the current UI culture to configured metadata, using the configured default only for neutral cultures. It synthesizes metadata for an unmatched culture and ignores cancellation.
- [KamiSama.Modules.Localization.Features.ListAvailableCultures](kamisama-modules-localization-features/kamisama-modules-localization-features-listavailablecultures/index.md) - Returns the configured mutable culture array directly and substitutes an empty array only for a null option value. It ignores cancellation.
- [KamiSama.Modules.Localization.Features.SetCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-setculture/index.md) - Validates configured culture metadata and appends a one-year request-culture cookie to the active response. It requires `AddHttpContextAccessor`, affects a later request, and ignores cancellation.
