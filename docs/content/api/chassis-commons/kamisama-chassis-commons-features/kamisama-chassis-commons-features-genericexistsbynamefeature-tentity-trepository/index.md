# GenericExistsByNameFeature<TEntity, TRepository>

<a id="genericexistsbynamefeature-tentity-trepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByNameFeature.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByNameFeature.cs#L9)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for exists-by-name checks. It keeps application feature code thin by delegating directly to the repository contract.

## Declaration

```csharp
public abstract class GenericExistsByNameFeature<TEntity, TRepository>(TRepository repository) :
	IExistsByNameFeature
	where TRepository : ILookupByNameRepository<TEntity>
```

## Example

```csharp
public sealed class ProductExistsByName(IProductRepository repository)
    : GenericExistsByNameFeature<Product, IProductRepository>(repository);

bool exists = await productExistsByName.ExistsByNameAsync("Keyboard", cancellationToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByNameFeature.cs#L9)

Implements an entity-name existence feature by delegating to a repository. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericExistsByNameFeature<TEntity, TRepository>(TRepository repository) :
	IExistsByNameFeature
	where TRepository : ILookupByNameRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used for existence checks. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByNameAsync](method-existsbynameasync-23.md) | Checks whether an entity exists for the supplied name by delegating to the repository. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-16.md) | Protected repository used by the exists-by-name flow. |

