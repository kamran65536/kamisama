# RemoveAttachementFromTicketComment

<a id="removeattachementfromticketcomment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/RemoveAttachementFromTicketComment.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/RemoveAttachementFromTicketComment.cs#L3)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Class`

## Description

Provides the `RemoveAttachementFromTicketComment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class RemoveAttachementFromTicketComment(ITicketRepository repository) : IRemoveAttachementFromTicketComment
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/RemoveAttachementFromTicketComment.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class RemoveAttachementFromTicketComment(ITicketRepository repository) : IRemoveAttachementFromTicketComment
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ITicketRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [DeleteAsync](method-deleteasync-6.md) | Runs the `DeleteAsync` operation on `RemoveAttachementFromTicketComment`. Use it when your code needs this specific behavior from the package. |

