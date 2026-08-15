# TicketAttachmentDto

<a id="ticketattachmentdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L44)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries a stored attachment reference without binary content. Resolve &lt;paramref name=&quot;ContentId&quot;/&gt; through the host application&apos;s content service.

## Declaration

```csharp
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L44)

Carries a stored attachment reference without binary content. Resolve &lt;paramref name=&quot;ContentId&quot;/&gt; through the host application&apos;s content service.

```csharp
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The ticket attachment identifier. |
| `ContentId` | `Guid` | `-` | The external content identifier. |
| `AuthorUserId` | `Guid` | `-` | The identifier of the user who attached the content. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

