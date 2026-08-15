# SetAsync

[Back to SetCulture](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs#L23)

Type: `KamiSama.Modules.Localization.Features.SetCulture`

Kind: `Method`

## Description

Finds a configured culture by case-insensitive name, requires an active HTTP context, and appends a request-culture cookie that expires in one year. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `culture` | `string` | `-` | The supported culture name to persist. A value is not handled and causes a null-reference failure. |
| `cancellationToken` | `CancellationToken` | `-` | Ignored by this implementation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto>` | The same configured metadata object selected for the cookie. |

## Example

```csharp
CultureInfoDto selected = await setCulture.SetAsync("fa-IR", CancellationToken.None);
// The response cookie participates in culture selection on a later request.
```

