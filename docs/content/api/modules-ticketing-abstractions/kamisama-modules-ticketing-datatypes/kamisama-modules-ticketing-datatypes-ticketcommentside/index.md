# TicketCommentSide

<a id="ticketcommentside"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketCommentSide.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketCommentSide.cs#L6)

Namespace: `KamiSama.Modules.Ticketing.DataTypes`

Kind: `Enum`

## Description

Identifies whether a ticket comment is attributed to the user or operator side. The value is supplied by comment callers except for the initial user comment created with a ticket.

## Declaration

```csharp
public enum TicketCommentSide
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Operator](enum-member-operator-11.md) | The comment belongs to the operator side. Use it with the surrounding package APIs when composing application code. |
| [User](enum-member-user-9.md) | The comment belongs to the user side. Use it with the surrounding package APIs when composing application code. |

