# KamiSama.Modules.Ticketing.Entities

[Back to KamiSama.Modules.Ticketing.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [Ticket](kamisama-modules-ticketing-entities-ticket/index.md) | Class | EF Core ticket aggregate root with a required category, comments, attachment references, workflow state, priority, author, and timestamps. `CanTransitionTo` exposes Core's transition table, while `IsEditable` identifies open and reopened tickets. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs#L7) |
| [TicketAttachment](kamisama-modules-ticketing-entities-ticketattachment/index.md) | Class | EF Core reference from a ticket comment to an external content identifier. It stores no content bytes or metadata and is cascade-deleted with its comment. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketAttachment.cs#L7) |
| [TicketCategory](kamisama-modules-ticketing-entities-ticketcategory/index.md) | Class | EF Core ticket category with a required 50-character name and timestamps. Duplicate checks occur in feature code, while provider migrations create no unique name index. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketCategory.cs#L7) |
| [TicketComment](kamisama-modules-ticketing-entities-ticketcomment/index.md) | Class | EF Core comment belonging to one ticket, with caller-attributed side and author, 400-character text, timestamps, and attachment references. Provider migrations cascade its deletion to attachments. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketComment.cs#L7) |
