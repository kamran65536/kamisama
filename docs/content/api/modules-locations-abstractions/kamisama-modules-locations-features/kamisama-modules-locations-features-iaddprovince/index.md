# IAddProvince

<a id="iaddprovince"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L17)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines province creation from `AddProvinceRequest`. Core saves immediately and performs no duplicate-name check.

## Declaration

```csharp
public interface IAddProvince : IAddFeature<AddProvinceRequest, ProvinceDto>;
```

## Example

```csharp
ProvinceDto province = await addProvince.AddAsync(new AddProvinceRequest("Central"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

