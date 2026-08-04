# FindTicketCategoryByName

<a id="findticketcategorybyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/FindTicketCategoryByName.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/FindTicketCategoryByName.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Features.Categories`

Kind: `Class`

## Description

Provides the `FindTicketCategoryByName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class FindTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericFindByNameFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository>(repository),
	IFindTicketCategoryByName
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/FindTicketCategoryByName.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class FindTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericFindByNameFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository>(repository),
	IFindTicketCategoryByName
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ITicketCategoryRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-10.md) | Runs the `ConvertToDto` operation on `FindTicketCategoryByName`. Use it when your code needs this specific behavior from the package. |

