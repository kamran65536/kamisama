# TicketAttachmentDto

<a id="ticketattachmentdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L10)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `TicketAttachmentDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L10)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The `Id` value passed to this member. |
| `ContentId` | `Guid` | `-` | The `ContentId` value passed to this member. |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

