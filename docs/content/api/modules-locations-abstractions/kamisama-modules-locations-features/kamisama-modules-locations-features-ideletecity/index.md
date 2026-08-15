# IDeleteCity

<a id="ideletecity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:46](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L46)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines city deletion by `Guid`. Core loads the row and saves its deletion immediately.

## Declaration

```csharp
public interface IDeleteCity : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteCity.DeleteAsync(cityId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

