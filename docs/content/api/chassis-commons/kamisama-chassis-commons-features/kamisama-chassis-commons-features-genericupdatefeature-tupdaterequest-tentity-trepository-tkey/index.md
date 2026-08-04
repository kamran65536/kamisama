# GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>

<a id="genericupdatefeature-tupdaterequest-tentity-trepository-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L8)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for update use cases. `UpdateAsync` loads the entity by id, runs duplicate checks, lets the derived class patch the entity, and saves it through the repository.

## Declaration

```csharp
public abstract class GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(TRepository repository) :
	IUpdateFeature<TUpdateRequest, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IUpdatableRepository<TEntity>
```

## Example

```csharp
public sealed class UpdateProductFeature(IProductRepository repository)
    : GenericUpdateFeature<UpdateProductRequest, Product, IProductRepository, Guid>(repository)
{
    protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        entity.Name = request.Name;
        entity.Price = request.Price;
        return Task.CompletedTask;
    }
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L8)

Generic implementation of `IUpdateFeature{TEntityDto, TKey}`. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(TRepository repository) :
	IUpdateFeature<TUpdateRequest, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IUpdatableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [CheckDuplicateAsync](method-checkduplicateasync-19.md) | Validation hook called after the entity is loaded and before it is patched. Override it to reject conflicting update requests. |
| [PatchEntityAsync](method-patchentityasync-22.md) | Mutation hook called after duplicate validation. Override it to copy request values onto the loaded entity before the base class saves it. |
| [UpdateAsync](method-updateasync-24.md) | Runs the complete update flow: load the entity by id, throw when missing, check duplicate state, patch the entity, and save it through the repository. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-15.md) | Protected repository used by derived update features. Use it when duplicate checks or patching need repository access. |

