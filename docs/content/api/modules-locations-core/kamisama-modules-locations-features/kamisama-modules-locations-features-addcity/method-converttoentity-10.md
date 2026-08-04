# ConvertToEntity

[Back to AddCity](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/AddCity.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/AddCity.cs#L10)

Type: `KamiSama.Modules.Locations.Features.AddCity`

Kind: `Method`

## Description

Runs the `ConvertToEntity` operation on `AddCity`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override async Task<City> ConvertToEntity(AddCityRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddCityRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<City>` | Returns a `Task<City>` value. |

## Example

No concise standalone example is available yet.

