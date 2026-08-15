# TicketCategory

<a id="ticketcategory"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/TicketCategory.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketCategory.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.Entities`

Kind: `Class`

## Description

EF Core ticket category with a required 50-character name and timestamps. Duplicate checks occur in feature code, while provider migrations create no unique name index.

## Declaration

```csharp
public class TicketCategory
```

## Example

```csharp
var category = new TicketCategory
{
    Id = Guid.NewGuid(),
    Name = "Billing",
    CreatedAt = DateTime.UtcNow,
    UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-15.md) | Gets or sets the category creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-10.md) | Gets or sets the category identifier. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-12.md) | Gets or sets the required category name, limited to 50 characters by the EF Core model. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-17.md) | Gets or sets the latest category update timestamp. Use it with the surrounding package APIs when composing application code. |

