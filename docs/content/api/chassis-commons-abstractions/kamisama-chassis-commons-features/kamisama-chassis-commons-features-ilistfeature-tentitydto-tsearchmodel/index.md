# IListFeature<TEntityDto, TSearchModel>

<a id="ilistfeature-tentitydto-tsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L26)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a paged list query that returns the standard `PagedResult{T}` shape. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListFeature<TEntityDto, TSearchModel> : IListFeature<TEntityDto, TSearchModel, PagedResult<TEntityDto>>
	where TSearchModel : SearchModel
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

