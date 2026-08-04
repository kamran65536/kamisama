# IExistsByIdFeature<TKey>

<a id="iexistsbyidfeature-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines the contract for `IExistsByIdFeature<TKey>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IExistsByIdFeature<TKey>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-14.md) | checks if entity exists or not. Use it with the surrounding package APIs when composing application code. |

