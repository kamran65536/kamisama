# ConvertToEntity

[Back to AddProvince](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/AddProvince.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/AddProvince.cs#L10)

Type: `KamiSama.Modules.Locations.Features.AddProvince`

Kind: `Method`

## Description

Runs the `ConvertToEntity` operation on `AddProvince`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<Province> ConvertToEntity(AddProvinceRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddProvinceRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<Province>` | Returns a `Task<Province>` value. |

## Example

No concise standalone example is available yet.

