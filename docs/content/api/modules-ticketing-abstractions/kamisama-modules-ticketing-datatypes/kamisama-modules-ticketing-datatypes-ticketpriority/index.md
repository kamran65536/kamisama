# TicketPriority

<a id="ticketpriority"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketPriority.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/DataTypes/TicketPriority.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.DataTypes`

Kind: `Enum`

## Description

Identifies the urgency assigned to a ticket. Core stores the numeric value and uses it as the default primary list ordering.

## Declaration

```csharp
public enum TicketPriority : int
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Critical](enum-member-critical-16.md) | The highest available urgency. Use it with the surrounding package APIs when composing application code. |
| [High](enum-member-high-14.md) | Represents the `High` value of `TicketPriority`. Use it with the surrounding package APIs when composing application code. |
| [Low](enum-member-low-10.md) | The lowest available urgency. Use it with the surrounding package APIs when composing application code. |
| [Medium](enum-member-medium-12.md) | A normal intermediate urgency. Use it with the surrounding package APIs when composing application code. |

