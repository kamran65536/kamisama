# IsEditable

[Back to Ticket](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs#L33)

Type: `KamiSama.Modules.Ticketing.Entities.Ticket`

Kind: `Method`

## Description

Determines whether the current status permits editing under the entity&apos;s workflow rule. Current feature services do not consistently invoke this rule before mutations.

## Declaration

```csharp
public bool IsEditable();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `bool` | for open or reopened tickets; otherwise . |

## Example

No concise standalone example is available yet.

