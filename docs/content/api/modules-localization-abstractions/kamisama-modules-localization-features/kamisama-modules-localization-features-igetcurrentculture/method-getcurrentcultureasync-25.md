# GetCurrentCultureAsync

[Back to IGetCurrentCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L25)

Type: `KamiSama.Modules.Localization.Features.IGetCurrentCulture`

Kind: `Method`

## Description

Returns metadata for the current UI culture according to the implementation&apos;s matching and fallback rules. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token the implementation may observe while resolving the current culture. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | The current culture metadata. |

## Example

```csharp
CultureInfoDto current = await getCurrentCulture.GetCurrentCultureAsync(cancellationToken);
```

