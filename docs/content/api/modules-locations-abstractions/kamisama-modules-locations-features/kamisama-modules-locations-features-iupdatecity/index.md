# IUpdateCity

<a id="iupdatecity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L42)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines updating a city's name and parent province. Core requires the new parent to exist and saves the tracked entity immediately.

## Declaration

```csharp
public interface IUpdateCity : IUpdateFeature<UpdateCityRequest, Guid>;
```

## Example

```csharp
await updateCity.UpdateAsync(cityId, new UpdateCityRequest(provinceId, "New Springfield"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

