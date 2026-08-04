# CityRepository

<a id="cityrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs#L9)

Namespace: `KamiSama.Modules.Locations.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `CityRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class CityRepository(LocationsDbContext context) :
	GenericRepository<City, CitySearchModel, LocationsDbContext>(context),
	ICityRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class CityRepository(LocationsDbContext context) :
	GenericRepository<City, CitySearchModel, LocationsDbContext>(context),
	ICityRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `LocationsDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-14.md) | Runs the `ApplySearchModel` operation on `CityRepository`. Use it when your code needs this specific behavior from the package. |
| [ExistsByIdAsync](method-existsbyidasync-41.md) | Runs the `ExistsByIdAsync` operation on `CityRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-38.md) | Runs the `FindByIdAsync` operation on `CityRepository`. Use it when your code needs this specific behavior from the package. |

