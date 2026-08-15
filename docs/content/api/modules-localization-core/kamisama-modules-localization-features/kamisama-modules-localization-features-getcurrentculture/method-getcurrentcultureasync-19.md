# GetCurrentCultureAsync

[Back to GetCurrentCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L19)

Type: `KamiSama.Modules.Localization.Features.GetCurrentCulture`

Kind: `Method`

## Description

Resolves the current UI culture synchronously, matches it by culture name using current-culture-insensitive comparison, and synthesizes metadata when no configured entry matches. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | Ignored by this implementation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | The matched configured object, or synthesized metadata for the resolved current UI culture. |

## Example

```csharp
CultureInfoDto current = await feature.GetCurrentCultureAsync(CancellationToken.None);
```

