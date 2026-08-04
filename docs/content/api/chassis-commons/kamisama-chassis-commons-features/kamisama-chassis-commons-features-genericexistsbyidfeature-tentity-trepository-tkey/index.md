# GenericExistsByIdFeature<TEntity, TRepository, TKey>

<a id="genericexistsbyidfeature-tentity-trepository-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByIdFeature.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L7)

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

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L7)

Generic Exists by Id Feature Implementation. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericExistsByIdFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IExistsByIdFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-21.md) | Checks whether an entity exists for the supplied key by delegating to the repository. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-14.md) | Protected repository used by the exists-by-id flow. |

