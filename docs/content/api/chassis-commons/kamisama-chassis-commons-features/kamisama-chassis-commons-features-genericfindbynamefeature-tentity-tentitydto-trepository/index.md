# GenericFindByNameFeature<TEntity, TEntityDto, TRepository>

<a id="genericfindbynamefeature-tentity-tentitydto-trepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByNameFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByNameFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for find-by-name use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.

## Declaration

```csharp
public abstract class GenericFindByNameFeature<TEntity, TEntityDto, TRepository>(TRepository repository) : 
	IFindByNameFeature<TEntityDto>
	where TRepository : ILookupByNameRepository<TEntity>
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByNameFeature.cs#L6)

Generic implementation of `IFindByNameFeature{TEntityDto}`. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericFindByNameFeature<TEntity, TEntityDto, TRepository>(TRepository repository) : 
	IFindByNameFeature<TEntityDto>
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
| [ConvertToDto](method-converttodto-17.md) | Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers. |
| [FindByNameAsync](method-findbynameasync-20.md) | Loads an entity by name through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-13.md) | Protected repository used by the find-by-name flow and available to derived mapping code. |

