# IListFeature<TEntityDto, TSearchModel, TPageResult>

<a id="ilistfeature-tentitydto-tsearchmodel-tpageresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines the contract for `IListFeature<TEntityDto, TSearchModel, TPageResult>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IListFeature<TEntityDto, TSearchModel, TPageResult>
	where TSearchModel : SearchModel
	where TPageResult : PagedResult<TEntityDto>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-16.md) | Runs the `ListAsync` operation on `IListFeature<TEntityDto, TSearchModel, TPageResult>`. Use it when your code needs this specific behavior from the package. |

