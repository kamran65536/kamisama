# LocalizationOptions

<a id="localizationoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs#L10)

Namespace: `KamiSama.Modules.Localization`

Kind: `Class`

## Description

Holds mutable supported-culture metadata and the default culture name bound from configuration. Culture arrays are exposed directly rather than copied.

## Declaration

```csharp
public class LocalizationOptions
```

## Example

```csharp
using KamiSama.Modules.Localization;
using KamiSama.Modules.Localization.Features;

var options = new LocalizationOptions
{
    DefaultCulture = "en-US",
    AvailableCultures =
    [
        new CultureInfoDto("English", "us", "en-US"),
        new CultureInfoDto("Persian", "ir", "fa-IR")
    ]
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [AvailableCultures](property-availablecultures-15.md) | Gets or sets the mutable culture metadata bound from `available-cultures`. The default contains United States English. |
| [DefaultCulture](property-defaultculture-21.md) | Gets or sets the fallback culture name bound from `default-culture`. The value must be accepted by `System.Globalization.CultureInfo` when the module is added. |

