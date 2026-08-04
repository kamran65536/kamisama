# IFindByIdFeature<TEntityDto, TKey>

<a id="ifindbyidfeature-tentitydto-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines the contract for `IFindByIdFeature<TEntityDto, TKey>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IFindByIdFeature<TEntityDto, TKey>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByIdAsync](method-findbyidasync-12.md) | Finds an &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; by it&apos;s id. Use it with the surrounding package APIs when composing application code. |

