# AddTicketCategoryRequest

<a id="addticketcategoryrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L42)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Supplies the name for a new ticket category. Core checks the name for a case-insensitive duplicate before saving.

## Declaration

```csharp
public record AddTicketCategoryRequest(string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L42)

Supplies the name for a new ticket category. Core checks the name for a case-insensitive duplicate before saving.

```csharp
public record AddTicketCategoryRequest(string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The category name to create. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

