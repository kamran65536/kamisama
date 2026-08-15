# GetCurrentCulture

<a id="getcurrentculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L11)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Class`

## Description

Maps the current UI culture to configured metadata, using the configured default only for neutral cultures. It synthesizes metadata for an unmatched culture and ignores cancellation.

## Declaration

```csharp
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
```

## Example

```csharp
var feature = new GetCurrentCulture(options);
CultureInfoDto current = await feature.GetCurrentCultureAsync(CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L11)

Maps `CultureInfo.CurrentUICulture` to configured culture metadata, falling back from a neutral current culture to the configured default. Use it with the surrounding package APIs when composing application code.

```csharp
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<LocalizationOptions>` | `-` | The bound localization options used for matching and neutral-culture fallback. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentCultureAsync](method-getcurrentcultureasync-19.md) | Resolves the current UI culture synchronously, matches it by culture name using current-culture-insensitive comparison, and synthesizes metadata when no configured entry matches. Use it with the surrounding package APIs when composing application code. |

