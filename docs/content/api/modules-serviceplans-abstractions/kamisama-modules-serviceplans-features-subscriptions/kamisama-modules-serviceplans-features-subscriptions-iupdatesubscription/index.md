# IUpdateSubscription

<a id="iupdatesubscription"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs#L16)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Interface`

## Description

Defines replacement of a subscription's subscriber, plan, lifecycle, and usage values. Core allows relationship reassignment and saves immediately without domain validation.

## Declaration

```csharp
public interface IUpdateSubscription : IUpdateFeature<UpdateSubscriptionRequest, Guid>;
```

## Example

```csharp
// Core permits subscriber, plan, lifecycle, and balance replacement.
await updateSubscription.UpdateAsync(subscriptionId, request, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

