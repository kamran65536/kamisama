# ListAvailableCultures

<a id="listavailablecultures"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L9)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Class`

## Description

Returns the configured mutable culture array directly and substitutes an empty array only for a null option value. It ignores cancellation.

## Declaration

```csharp
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
```

## Example

```csharp
var feature = new ListAvailableCultures(options);
CultureInfoDto[] cultures = await feature.ListAsync(CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L9)

Returns the configured culture metadata from the options instance without copying the array. Use it with the surrounding package APIs when composing application code.

```csharp
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<LocalizationOptions>` | `-` | The bound localization options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-17.md) | Returns the mutable configured array, or a new empty array when the configured value is ; no asynchronous work is performed. Use it with the surrounding package APIs when composing application code. |

