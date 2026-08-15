# KamiSama.Modules.Localization.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral localization feature contracts and culture metadata for listing, reading, and selecting application cultures. Reference this package when callers or implementations should not depend on the ASP.NET Core localization module.

## How to use

```shell
dotnet add package KamiSama.Modules.Localization.Abstractions --version 10.0.0
```

Depend on these interfaces from application code or implement them in a localization provider without referencing the ASP.NET Core core package:

```csharp
using KamiSama.Modules.Localization.Features;

public sealed class CultureMenu(
    IListAvailableCultures cultures,
    IGetCurrentCulture currentCulture,
    ISetCulture setCulture)
{
    public Task<CultureInfoDto[]> ListAsync(CancellationToken token) => cultures.ListAsync(token);
    public Task<CultureInfoDto> CurrentAsync(CancellationToken token) => currentCulture.GetCurrentCultureAsync(token);
    public Task<CultureInfoDto> SelectAsync(string name, CancellationToken token) => setCulture.SetAsync(name, token);
}
```

These contracts do not prescribe storage, request integration, cancellation guarantees, culture validation, or whether returned arrays are snapshots. Implementations own those semantics.

## Namespaces

- [KamiSama.Modules.Localization.Features](kamisama-modules-localization-features/index.md) (4 types)

## Types

- [KamiSama.Modules.Localization.Features.CultureInfoDto](kamisama-modules-localization-features/kamisama-modules-localization-features-cultureinfodto/index.md) - Carries a display label, application-defined flag representation, and .NET culture name. It is shared by localization contracts and implementations.
- [KamiSama.Modules.Localization.Features.IGetCurrentCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-igetcurrentculture/index.md) - Defines provider-neutral current-culture lookup. Implementations decide the execution context, matching, fallback, and cancellation behavior.
- [KamiSama.Modules.Localization.Features.IListAvailableCultures](kamisama-modules-localization-features/kamisama-modules-localization-features-ilistavailablecultures/index.md) - Defines provider-neutral culture discovery. Implementations decide storage, cancellation, and whether returned arrays are mutable or copied.
- [KamiSama.Modules.Localization.Features.ISetCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-isetculture/index.md) - Defines provider-neutral culture selection. Implementations decide validation, persistence, request effects, and cancellation behavior.
