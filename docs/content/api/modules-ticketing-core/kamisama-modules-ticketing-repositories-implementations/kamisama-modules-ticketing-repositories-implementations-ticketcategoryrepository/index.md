# TicketCategoryRepository

<a id="ticketcategoryrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `TicketCategoryRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class TicketCategoryRepository(TicketingDbContext context) :
	GenericRepository<TicketCategory, TicketCategorySearchModel, TicketingDbContext>(context),
	ITicketCategoryRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class TicketCategoryRepository(TicketingDbContext context) :
	GenericRepository<TicketCategory, TicketCategorySearchModel, TicketingDbContext>(context),
	ITicketCategoryRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TicketingDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-10.md) | Runs the `ApplySearchModel` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package. |
| [ExistsByIdAsync](method-existsbyidasync-27.md) | Runs the `ExistsByIdAsync` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package. |
| [ExistsByNameAsync](method-existsbynameasync-31.md) | Runs the `ExistsByNameAsync` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-25.md) | Runs the `FindByIdAsync` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByNameAsync](method-findbynameasync-29.md) | Runs the `FindByNameAsync` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package. |

