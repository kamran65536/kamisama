# GetCurrentCultureAsync

[Back to IGetCurrentCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L9)

Type: `KamiSama.Modules.Localization.Features.IGetCurrentCulture`

Kind: `Method`

## Description

Runs the `GetCurrentCultureAsync` operation on `IGetCurrentCulture`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | Returns a `Task<CultureInfoDto>` value. |

## Example

No concise standalone example is available yet.

