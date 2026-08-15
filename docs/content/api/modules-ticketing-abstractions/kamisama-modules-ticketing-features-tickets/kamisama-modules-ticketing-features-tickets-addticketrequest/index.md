# AddTicketRequest

<a id="addticketrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:81](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L81)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Supplies the data used to open a ticket, create its initial user-side comment, and attach external content references. Core requires the category to exist and forces the initial status to `TicketStatus.Open`.

## Declaration

```csharp
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L81)

Supplies the data used to open a ticket, create its initial user-side comment, and attach external content references. Core requires the category to exist and forces the initial status to `TicketStatus.Open`.

```csharp
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `AuthorUserId` | `Guid` | `-` | The identifier of the user opening the ticket and authoring its initial comment. |
| `Title` | `string` | `-` | The ticket title. |
| `CategoryId` | `Guid` | `-` | The identifier of an existing ticket category. |
| `InitialComment` | `string` | `-` | The initial user-side comment text. |
| `Priority` | `TicketPriority` | `-` | The initial ticket priority. |
| `InitialAttachmentContentIds` | `List<Guid>` | `-` | External content identifiers to attach to the initial comment. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

