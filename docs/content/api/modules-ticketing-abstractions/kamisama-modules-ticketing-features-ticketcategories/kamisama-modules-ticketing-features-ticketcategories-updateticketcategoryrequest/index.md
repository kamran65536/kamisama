# UpdateTicketCategoryRequest

<a id="updateticketcategoryrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L48)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Supplies the replacement name for an existing ticket category. The target category identifier is passed separately to the update feature.

## Declaration

```csharp
public record UpdateTicketCategoryRequest(string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L48)

Supplies the replacement name for an existing ticket category. The target category identifier is passed separately to the update feature.

```csharp
public record UpdateTicketCategoryRequest(string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement category name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

