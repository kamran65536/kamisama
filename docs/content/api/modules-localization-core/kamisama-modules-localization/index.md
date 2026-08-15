# KamiSama.Modules.Localization

[Back to KamiSama.Modules.Localization.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [ExtendedWebApplicationBuilderExtensions](kamisama-modules-localization-extendedwebapplicationbuilderextensions/index.md) | Class | Adds request localization and the localization core module in the required order. Provider insertion produces Accept-Language, query-string, then cookie precedence. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L51) |
| [LocalizationModule](kamisama-modules-localization-localizationmodule/index.md) | Class | Registers localization options, resources, and attributed scoped feature implementations. A preceding request-localization module owns middleware configuration. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L17) |
| [LocalizationOptions](kamisama-modules-localization-localizationoptions/index.md) | Class | Holds mutable supported-culture metadata and the default culture name bound from configuration. Culture arrays are exposed directly rather than copied. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs#L10) |
