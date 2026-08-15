# IUpdateProvince

<a id="iupdateprovince"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L21)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines province update by `Guid`. Core replaces the name, saves immediately, and performs no duplicate-name check.

## Declaration

```csharp
public interface IUpdateProvince : IUpdateFeature<UpdateProvinceRequest, Guid>;
```

## Example

```csharp
await updateProvince.UpdateAsync(provinceId, new UpdateProvinceRequest("Central District"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

