# ProvinceRepository

<a id="provincerepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Implementations/ProvinceRepository.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/ProvinceRepository.cs#L8)

Namespace: `KamiSama.Modules.Locations.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `ProvinceRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class ProvinceRepository(LocationsDbContext context) :
	GenericRepository<Province, ProvinceSearchModel, LocationsDbContext>(context),
	IProvinceRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/ProvinceRepository.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ProvinceRepository(LocationsDbContext context) :
	GenericRepository<Province, ProvinceSearchModel, LocationsDbContext>(context),
	IProvinceRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `LocationsDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-13.md) | Runs the `ApplySearchModel` operation on `ProvinceRepository`. Use it when your code needs this specific behavior from the package. |
| [ExistsByIdAsync](method-existsbyidasync-30.md) | Runs the `ExistsByIdAsync` operation on `ProvinceRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-27.md) | Runs the `FindByIdAsync` operation on `ProvinceRepository`. Use it when your code needs this specific behavior from the package. |

