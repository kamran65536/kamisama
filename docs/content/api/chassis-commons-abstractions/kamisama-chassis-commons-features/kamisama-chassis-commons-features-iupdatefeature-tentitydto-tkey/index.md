# IUpdateFeature<TEntityDto, TKey>

<a id="iupdatefeature-tentitydto-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Updates an entity from the database. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IUpdateFeature<TEntityDto, TKey>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [UpdateAsync](method-updateasync-11.md) | Runs the `UpdateAsync` operation on `IUpdateFeature<TEntityDto, TKey>`. Use it when your code needs this specific behavior from the package. |

