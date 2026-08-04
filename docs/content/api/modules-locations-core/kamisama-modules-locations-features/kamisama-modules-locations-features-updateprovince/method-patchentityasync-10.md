# PatchEntityAsync

[Back to UpdateProvince](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/UpdateProvince.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/UpdateProvince.cs#L10)

Type: `KamiSama.Modules.Locations.Features.UpdateProvince`

Kind: `Method`

## Description

Runs the `PatchEntityAsync` operation on `UpdateProvince`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task PatchEntityAsync(Province entity, UpdateProvinceRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `Province` | `-` | The `entity` value passed to this member. |
| `request` | `UpdateProvinceRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

