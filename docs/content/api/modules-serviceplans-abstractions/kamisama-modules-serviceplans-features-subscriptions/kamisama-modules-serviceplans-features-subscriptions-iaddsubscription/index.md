# IAddSubscription

<a id="iaddsubscription"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs#L12)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Interface`

## Description

Defines subscription creation for an existing subscriber and plan. Core accepts caller-selected lifecycle and usage values without eligibility, transition, range, or ownership validation.

## Declaration

```csharp
public interface IAddSubscription : IAddFeature<AddSubscriptionRequest, SubscriptionDto>;
```

## Example

```csharp
// Validate authorization and domain values before calling Core.
SubscriptionDto subscription = await addSubscription.AddAsync(request, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

