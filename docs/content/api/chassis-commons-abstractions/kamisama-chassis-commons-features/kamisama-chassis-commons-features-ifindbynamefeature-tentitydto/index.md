# IFindByNameFeature<TEntityDto>

<a id="ifindbynamefeature-tentitydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines the contract for `IFindByNameFeature<TEntityDto>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IFindByNameFeature<TEntityDto>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByNameAsync](method-findbynameasync-12.md) | Finds an &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; by it&apos;s name. Use it with the surrounding package APIs when composing application code. |

