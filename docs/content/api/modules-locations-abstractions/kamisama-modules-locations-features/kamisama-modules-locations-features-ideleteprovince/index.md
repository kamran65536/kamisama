# IDeleteProvince

<a id="ideleteprovince"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L25)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines province deletion by `Guid`. Core saves immediately; the restricted relationship can make deletion fail while cities reference the province.

## Declaration

```csharp
public interface IDeleteProvince : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteProvince.DeleteAsync(provinceId, cancellationToken);
// Core's restricted relationship prevents deleting a province that still has cities.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

