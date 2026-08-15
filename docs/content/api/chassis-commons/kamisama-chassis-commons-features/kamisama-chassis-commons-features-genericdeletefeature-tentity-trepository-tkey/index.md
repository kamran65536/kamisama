# GenericDeleteFeature<TEntity, TRepository, TKey>

<a id="genericdeletefeature-tentity-trepository-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericDeleteFeature.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericDeleteFeature.cs#L9)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for delete use cases. `DeleteAsync` loads the entity by id, calls `CanBeDeletedAsync`, and deletes the entity only when the hook allows it.

## Declaration

```csharp
public abstract class GenericDeleteFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IDeleteFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IDeletableRepository<TEntity>
```

## Example

```csharp
public sealed class DeleteProductFeature(IProductRepository repository)
    : GenericDeleteFeature<Product, IProductRepository, Guid>(repository)
{
    protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)
        => Task.FromResult(!entity.HasOpenOrders);
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericDeleteFeature.cs#L9)

Implements the delete workflow by loading an entity, applying a deletion guard, and deleting it when allowed. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericDeleteFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IDeleteFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IDeletableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used by the workflow and deletion guard. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [CanBeDeletedAsync](method-canbedeletedasync-23.md) | Deletion guard called after the entity is loaded and before deletion. Override it to prevent deletes for entities that are still referenced or otherwise protected. |
| [DeleteAsync](method-deleteasync-30.md) | Runs the complete delete flow: load the entity by id, throw when missing, ask `CanBeDeletedAsync`, and delete through the repository only when allowed. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-16.md) | Protected repository used by derived delete features. Use it when the deletion rule needs additional repository data. |

