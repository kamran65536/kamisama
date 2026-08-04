# AddTicketCommentRequest

<a id="addticketcommentrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L16)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `AddTicketCommentRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L16)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `TicketId` | `Guid` | `-` | The `TicketId` value passed to this member. |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |
| `Side` | `TicketCommentSide` | `-` | The `Side` value passed to this member. |
| `Comment` | `string` | `-` | The `Comment` value passed to this member. |
| `AttachmentContentIds` | `List<Guid>` | `-` | The `AttachmentContentIds` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

