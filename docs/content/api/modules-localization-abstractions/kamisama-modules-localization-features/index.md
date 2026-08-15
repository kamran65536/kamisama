# KamiSama.Modules.Localization.Features

[Back to KamiSama.Modules.Localization.Abstractions](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [CultureInfoDto](kamisama-modules-localization-features-cultureinfodto/index.md) | Record | Carries a display label, application-defined flag representation, and .NET culture name. It is shared by localization contracts and implementations. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs#L9) |
| [IGetCurrentCulture](kamisama-modules-localization-features-igetcurrentculture/index.md) | Interface | Defines provider-neutral current-culture lookup. Implementations decide the execution context, matching, fallback, and cancellation behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L18) |
| [IListAvailableCultures](kamisama-modules-localization-features-ilistavailablecultures/index.md) | Interface | Defines provider-neutral culture discovery. Implementations decide storage, cancellation, and whether returned arrays are mutable or copied. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L6) |
| [ISetCulture](kamisama-modules-localization-features-isetculture/index.md) | Interface | Defines provider-neutral culture selection. Implementations decide validation, persistence, request effects, and cancellation behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L31) |
