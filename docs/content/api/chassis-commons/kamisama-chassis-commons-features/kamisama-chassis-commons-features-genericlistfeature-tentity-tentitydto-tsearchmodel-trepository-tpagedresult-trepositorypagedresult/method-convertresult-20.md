# ConvertResult

[Back to GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L20)

Type: `KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>`

Kind: `Method`

## Description

Result-shaping hook for custom paged result types. Override it to translate the repository result into the result type exposed by the feature.

## Declaration

```csharp
protected abstract Task<TPagedResult> ConvertResult(TRepositoryPagedResult repositoryResult, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repositoryResult` | `TRepositoryPagedResult` | `-` | The `repositoryResult` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | Returns a `Task<TPagedResult>` value. |

## Example

```csharp
protected override Task<ProductPage> ConvertResult(ProductRepositoryPage repositoryResult, CancellationToken cancellationToken)
    => Task.FromResult(ProductPage.From(repositoryResult));
```

