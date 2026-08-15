# DefaultCulture

[Back to LocalizationOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs#L21)

Type: `KamiSama.Modules.Localization.LocalizationOptions`

Kind: `Property`

## Description

Gets or sets the fallback culture name bound from `default-culture`. The value must be accepted by `System.Globalization.CultureInfo` when the module is added.

## Declaration

```csharp
public string DefaultCulture { get; set; } = "en-US";
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `string` value. |

## Example

```csharp
options.DefaultCulture = "en-US";
```

