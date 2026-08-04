# IProvinceRepository

<a id="iprovincerepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Abstractions/IProvinceRepository.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Abstractions/IProvinceRepository.cs#L5)

Namespace: `KamiSama.Modules.Locations.Repositories.Abstractions`

Kind: `Interface`

## Description

Repository implementation or contract for `IProvinceRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal interface IProvinceRepository :
	IGenericRepository<Province, ProvinceSearchModel>,
	ILookupByIdRepository<Province, Guid>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

