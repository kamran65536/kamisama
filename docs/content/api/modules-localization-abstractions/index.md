# KamiSama.Modules.Localization.Abstractions

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Localization feature contracts and DTOs for culture selection. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Modules.Localization.Abstractions --version 10.0.10
```

## Namespaces

- [KamiSama.Modules.Localization.Features](kamisama-modules-localization-features/index.md) (4 types)

## Types

- [KamiSama.Modules.Localization.Features.CultureInfoDto](kamisama-modules-localization-features/kamisama-modules-localization-features-cultureinfodto/index.md) - Provides the `CultureInfoDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Localization.Features.IGetCurrentCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-igetcurrentculture/index.md) - Defines the contract for `IGetCurrentCulture` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Modules.Localization.Features.IListAvailableCultures](kamisama-modules-localization-features/kamisama-modules-localization-features-ilistavailablecultures/index.md) - Defines the contract for `IListAvailableCultures` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Modules.Localization.Features.ISetCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-isetculture/index.md) - Defines the contract for `ISetCulture` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
