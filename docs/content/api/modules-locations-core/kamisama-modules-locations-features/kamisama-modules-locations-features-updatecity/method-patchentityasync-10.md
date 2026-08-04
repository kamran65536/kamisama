# PatchEntityAsync

[Back to UpdateCity](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/UpdateCity.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/UpdateCity.cs#L10)

Type: `KamiSama.Modules.Locations.Features.UpdateCity`

Kind: `Method`

## Description

Runs the `PatchEntityAsync` operation on `UpdateCity`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override async Task PatchEntityAsync(City entity, UpdateCityRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `City` | `-` | The `entity` value passed to this member. |
| `request` | `UpdateCityRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

