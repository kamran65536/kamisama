# KamiSama.Modules.Localization.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Localization module implementation for available cultures, current culture, and request culture handling. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Modules.Localization.Core --version 10.0.10
```

## Namespaces

- [KamiSama.Modules.Localization](kamisama-modules-localization/index.md) (3 types)
- [KamiSama.Modules.Localization.Features](kamisama-modules-localization-features/index.md) (3 types)

## Types

- [KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions](kamisama-modules-localization/kamisama-modules-localization-extendedwebapplicationbuilderextensions/index.md) - Provides the `ExtendedWebApplicationBuilderExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Localization.LocalizationModule](kamisama-modules-localization/kamisama-modules-localization-localizationmodule/index.md) - ASP.NET Core web-module implementation for `LocalizationModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.
- [KamiSama.Modules.Localization.LocalizationOptions](kamisama-modules-localization/kamisama-modules-localization-localizationoptions/index.md) - Configuration object for `LocalizationOptions`. Use it when binding settings or configuring the related package services.
- [KamiSama.Modules.Localization.Features.GetCurrentCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-getcurrentculture/index.md) - Provides the `GetCurrentCulture` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Localization.Features.ListAvailableCultures](kamisama-modules-localization-features/kamisama-modules-localization-features-listavailablecultures/index.md) - Provides the `ListAvailableCultures` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Localization.Features.SetCulture](kamisama-modules-localization-features/kamisama-modules-localization-features-setculture/index.md) - Provides the `SetCulture` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
