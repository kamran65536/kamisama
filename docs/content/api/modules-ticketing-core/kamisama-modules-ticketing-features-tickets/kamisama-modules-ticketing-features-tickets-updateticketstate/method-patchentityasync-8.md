# PatchEntityAsync

[Back to UpdateTicketState](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/UpdateTicketState.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/UpdateTicketState.cs#L8)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketState`

Kind: `Method`

## Description

Runs the `PatchEntityAsync` operation on `UpdateTicketState`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task PatchEntityAsync(Ticket entity, UpdateTicketStateRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `Ticket` | `-` | The `entity` value passed to this member. |
| `request` | `UpdateTicketStateRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

