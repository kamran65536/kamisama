# ExistsTicketCategoryByName

<a id="existsticketcategorybyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/ExistsTicketCategoryByName.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/ExistsTicketCategoryByName.cs#L6)

Namespace: `KamiSama.Modules.Ticketing.Features.Categories`

Kind: `Class`

## Description

Provides the `ExistsTicketCategoryByName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ExistsTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericExistsByNameFeature<TicketCategory, ITicketCategoryRepository>(repository),
	IExistsByNameFeature
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/ExistsTicketCategoryByName.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ExistsTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericExistsByNameFeature<TicketCategory, ITicketCategoryRepository>(repository),
	IExistsByNameFeature
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ITicketCategoryRepository` | `-` | The `repository` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

