# IFindProvinceById

<a id="ifindprovincebyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L13)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines province lookup by `Guid`. Core throws the generic province not-found HTTP exception when no row matches.

## Declaration

```csharp
public interface IFindProvinceById : IFindByIdFeature<ProvinceDto, Guid>;
```

## Example

```csharp
ProvinceDto province = await findProvinceById.FindByIdAsync(provinceId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

