# KamiSama.Modules.Ticketing.DataTypes

[Back to KamiSama.Modules.Ticketing.Abstractions](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [TicketCommentSide](kamisama-modules-ticketing-datatypes-ticketcommentside/index.md) | Enum | Identifies whether a ticket comment is attributed to the user or operator side. The value is supplied by comment callers except for the initial user comment created with a ticket. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketCommentSide.cs#L6) |
| [TicketPriority](kamisama-modules-ticketing-datatypes-ticketpriority/index.md) | Enum | Identifies the urgency assigned to a ticket. Core stores the numeric value and uses it as the default primary list ordering. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketPriority.cs#L7) |
| [TicketStatus](kamisama-modules-ticketing-datatypes-ticketstatus/index.md) | Enum | Defines the open, reopened, resolved, and closed workflow states. Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; closed is terminal. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketStatus.cs#L7) |
