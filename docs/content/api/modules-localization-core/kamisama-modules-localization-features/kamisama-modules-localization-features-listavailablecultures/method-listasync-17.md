# ListAsync

[Back to ListAvailableCultures](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L17)

Type: `KamiSama.Modules.Localization.Features.ListAvailableCultures`

Kind: `Method`

## Description

Returns the mutable configured array, or a new empty array when the configured value is ; no asynchronous work is performed. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | Ignored by this implementation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto[]>` | The configured array instance or an empty array. |

## Example

```csharp
CultureInfoDto[] cultures = await feature.ListAsync(CancellationToken.None);
// The returned configured array is not copied.
```

