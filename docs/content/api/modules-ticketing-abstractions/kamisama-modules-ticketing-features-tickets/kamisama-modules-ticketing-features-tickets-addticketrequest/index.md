# AddTicketRequest

<a id="addticketrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L13)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `AddTicketRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L13)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |
| `Title` | `string` | `-` | The `Title` value passed to this member. |
| `CategoryId` | `Guid` | `-` | The `CategoryId` value passed to this member. |
| `InitialComment` | `string` | `-` | The `InitialComment` value passed to this member. |
| `Priority` | `TicketPriority` | `-` | The `Priority` value passed to this member. |
| `InitialAttachmentContentIds` | `List<Guid>` | `-` | The `InitialAttachmentContentIds` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

