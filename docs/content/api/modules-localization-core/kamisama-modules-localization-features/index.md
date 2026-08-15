# KamiSama.Modules.Localization.Features

[Back to KamiSama.Modules.Localization.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [GetCurrentCulture](kamisama-modules-localization-features-getcurrentculture/index.md) | Class | Maps the current UI culture to configured metadata, using the configured default only for neutral cultures. It synthesizes metadata for an unmatched culture and ignores cancellation. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L11) |
| [ListAvailableCultures](kamisama-modules-localization-features-listavailablecultures/index.md) | Class | Returns the configured mutable culture array directly and substitutes an empty array only for a null option value. It ignores cancellation. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L9) |
| [SetCulture](kamisama-modules-localization-features-setculture/index.md) | Class | Validates configured culture metadata and appends a one-year request-culture cookie to the active response. It requires `AddHttpContextAccessor`, affects a later request, and ignores cancellation. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs#L13) |
