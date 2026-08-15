# TicketStatus

<a id="ticketstatus"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketStatus.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketStatus.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.DataTypes`

Kind: `Enum`

## Description

Defines the open, reopened, resolved, and closed workflow states. Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; closed is terminal.

## Declaration

```csharp
public enum TicketStatus : int
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Closed](enum-member-closed-16.md) | The ticket is closed, non-editable, and terminal. Use it with the surrounding package APIs when composing application code. |
| [Open](enum-member-open-10.md) | The ticket is active, can be edited, and can transition to resolved. Use it with the surrounding package APIs when composing application code. |
| [Reopened](enum-member-reopened-12.md) | The ticket was reactivated after resolution, can be edited, and can transition to resolved. Use it with the surrounding package APIs when composing application code. |
| [Resolved](enum-member-resolved-14.md) | The reported issue has been resolved and can be reopened or closed. Use it with the surrounding package APIs when composing application code. |

