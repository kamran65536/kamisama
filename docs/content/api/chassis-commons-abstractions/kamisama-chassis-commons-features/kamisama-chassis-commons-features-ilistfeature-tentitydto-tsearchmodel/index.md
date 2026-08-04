# IListFeature<TEntityDto, TSearchModel>

<a id="ilistfeature-tentitydto-tsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L21)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines the contract for `IListFeature<TEntityDto, TSearchModel>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IListFeature<TEntityDto, TSearchModel> : IListFeature<TEntityDto, TSearchModel, PagedResult<TEntityDto>>
	where TSearchModel : SearchModel
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

