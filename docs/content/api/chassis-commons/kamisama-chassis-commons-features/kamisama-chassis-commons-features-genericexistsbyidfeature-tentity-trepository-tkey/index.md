# GenericExistsByIdFeature<TEntity, TRepository, TKey>

<a id="genericexistsbyidfeature-tentity-trepository-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByIdFeature.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L11)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for exists-by-id checks. It keeps application feature code thin by delegating directly to the repository contract.

## Declaration

```csharp
public abstract class GenericExistsByIdFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IExistsByIdFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
```

## Example

```csharp
public sealed class ProductExistsById(IProductRepository repository)
    : GenericExistsByIdFeature<Product, IProductRepository, Guid>(repository);

bool exists = await productExistsById.ExistsByIdAsync(productId, cancellationToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L11)

Implements an entity-identifier existence feature by delegating to a repository. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericExistsByIdFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IExistsByIdFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used for existence checks. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-25.md) | Checks whether an entity exists for the supplied key by delegating to the repository. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-18.md) | Protected repository used by the exists-by-id flow. |

