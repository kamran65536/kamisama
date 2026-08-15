# SetAsync

[Back to ISetCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L39)

Type: `KamiSama.Modules.Localization.Features.ISetCulture`

Kind: `Method`

## Description

Selects the requested culture according to the implementation&apos;s validation and persistence behavior. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `culture` | `string` | `-` | The culture name to select. |
| `cancellationToken` | `CancellationToken` | `-` | A token the implementation may observe while selecting the culture. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | The metadata for the selected culture. |

## Example

```csharp
CultureInfoDto selected = await setCulture.SetAsync("fa-IR", cancellationToken);
```

