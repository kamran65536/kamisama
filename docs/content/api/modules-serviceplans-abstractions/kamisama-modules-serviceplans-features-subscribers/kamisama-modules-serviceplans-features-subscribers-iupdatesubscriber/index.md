# IUpdateSubscriber

<a id="iupdatesubscriber"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs#L16)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Interface`

## Description

Defines replacement of a subscriber's external identifier and enabled state. Core does not authorize reassignment and saves immediately.

## Declaration

```csharp
public interface IUpdateSubscriber : IUpdateFeature<UpdateSubscriberRequest, Guid>;
```

## Example

```csharp
await updateSubscriber.UpdateAsync(subscriberId,
    new UpdateSubscriberRequest(externalUserId, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

