# ITicketCategoryRepository

<a id="iticketcategoryrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketCategoryRepository.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketCategoryRepository.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Abstractions`

Kind: `Interface`

## Description

Repository implementation or contract for `ITicketCategoryRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal interface ITicketCategoryRepository :
	IGenericRepository<TicketCategory, TicketCategorySearchModel>,
	ILookupByIdRepository<TicketCategory, Guid>,
	ILookupByNameRepository<TicketCategory>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

