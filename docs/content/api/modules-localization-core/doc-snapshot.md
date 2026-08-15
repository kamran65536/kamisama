---
last-checked-utc: 2026-08-14T23:59:09Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions
---

# Documentation Snapshot

The package description, public API summaries, request-provider ordering, request and cookie timing, cancellation and mutability limitations, prerequisites, and example coverage were reviewed against the source at the recorded root version.

## Description

ASP.NET Core localization registration and scoped features for configured culture discovery, current-culture lookup, and culture-selection cookies.
Use it to bind localization settings and compose request localization through `KamiSama.Modules`.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the required root-version command for repository documentation; when installing from NuGet, replace it with a version that is actually available.

```shell
dotnet add package KamiSama.Modules.Localization.Core --version 10.0.0
```

Register `IHttpContextAccessor` with `AddHttpContextAccessor`, add the localization module from its configuration section, and finish through the extended builder. Effective request-culture precedence is Accept-Language header, then query string, then cookie because each provider is inserted at the front. `SetCulture.SetAsync` appends a one-year response cookie but does not change the current request; the cookie participates on a later request and still loses to a header or query selection.

All three feature methods complete synchronously and ignore cancellation. Available-culture arrays remain mutable and `ListAvailableCultures.ListAsync` returns the configured array directly. `GetCurrentCulture` uses the configured default only for a neutral current UI culture and synthesizes metadata when no configured item matches.

## Example decisions

`LocalizationOptions`, `LocalizationModule`, `ListAvailableCultures`, `GetCurrentCulture`, and `SetCulture` have direct full-name-matched class examples. Static `ExtendedWebApplicationBuilderExtensions` is exempt because the package How-to and exact `AddLocalizationModule` member example cover registration, prerequisites, ordering, and build behavior.
