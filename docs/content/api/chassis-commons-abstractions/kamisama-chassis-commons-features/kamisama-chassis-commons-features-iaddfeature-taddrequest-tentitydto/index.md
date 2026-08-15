# IAddFeature<TAddRequest, TEntityDto>

<a id="iaddfeature-taddrequest-tentitydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IAddFeature.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IAddFeature.cs#L8)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a create use case that accepts a request and returns the created entity DTO. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IAddFeature<TAddRequest, TEntityDto>
```

## Example

```csharp
ProductDto created = await addProduct.AddAsync(
    new AddProductRequest("Keyboard", 120m), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-16.md) | Creates an entity from the request and returns its DTO representation. Use it with the surrounding package APIs when composing application code. |

