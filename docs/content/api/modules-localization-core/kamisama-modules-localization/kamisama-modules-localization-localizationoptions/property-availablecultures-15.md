# AvailableCultures

[Back to LocalizationOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationOptions.cs#L15)

Type: `KamiSama.Modules.Localization.LocalizationOptions`

Kind: `Property`

## Description

Gets or sets the mutable culture metadata bound from `available-cultures`. The default contains United States English.

## Declaration

```csharp
public CultureInfoDto[] AvailableCultures { get; set; } = [new("English (United States)", "en-US", "en-US")];
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `CultureInfoDto[]` value. |

## Example

```csharp
options.AvailableCultures = [new CultureInfoDto("English", "us", "en-US")];
```

