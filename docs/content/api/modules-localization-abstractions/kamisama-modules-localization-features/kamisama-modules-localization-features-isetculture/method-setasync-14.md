# SetAsync

[Back to ISetCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L14)

Type: `KamiSama.Modules.Localization.Features.ISetCulture`

Kind: `Method`

## Description

Runs the `SetAsync` operation on `ISetCulture`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
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

