# SetAsync

[Back to SetCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs#L10)

Type: `KamiSama.Modules.Localization.Features.SetCulture`

Kind: `Method`

## Description

Runs the `SetAsync` operation on `SetCulture`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `culture` | `string` | `-` | The `culture` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | Returns a `Task<CultureInfoDto>` value. |

## Example

No concise standalone example is available yet.

