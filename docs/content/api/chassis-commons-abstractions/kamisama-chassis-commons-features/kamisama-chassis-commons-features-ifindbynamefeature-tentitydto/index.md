# IFindByNameFeature<TEntityDto>

<a id="ifindbynamefeature-tentitydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs#L7)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a query that returns one entity DTO by name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindByNameFeature<TEntityDto>
```

## Example

```csharp
ProductDto product = await findProduct.FindByNameAsync("Keyboard", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByNameAsync](method-findbynameasync-15.md) | Finds an entity by name and returns its &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; representation. Use it with the surrounding package APIs when composing application code. |

