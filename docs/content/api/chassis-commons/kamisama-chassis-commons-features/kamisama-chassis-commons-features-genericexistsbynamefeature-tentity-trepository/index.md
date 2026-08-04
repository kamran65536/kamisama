# GenericExistsByNameFeature<TEntity, TRepository>

<a id="genericexistsbynamefeature-tentity-trepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByNameFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByNameFeature.cs#L6)

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

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByNameFeature.cs#L6)

Generic Exists by Id Feature Implementation. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericExistsByNameFeature<TEntity, TRepository>(TRepository repository) :
	IExistsByNameFeature
	where TRepository : ILookupByNameRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByNameAsync](method-existsbynameasync-17.md) | Checks whether an entity exists for the supplied name by delegating to the repository. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-13.md) | Protected repository used by the exists-by-name flow. |

