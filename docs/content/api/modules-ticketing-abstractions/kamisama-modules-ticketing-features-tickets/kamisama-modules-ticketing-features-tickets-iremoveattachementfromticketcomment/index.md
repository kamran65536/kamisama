# IRemoveAttachementFromTicketComment

<a id="iremoveattachementfromticketcomment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L45)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Removes a ticket attachment by attachment identifier. The misspelling in this public contract name is retained by the current API.

## Declaration

```csharp
public interface IRemoveAttachementFromTicketComment : IDeleteFeature<Guid>;
```

## Example

```csharp
await removeAttachment.DeleteAsync(attachmentId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

