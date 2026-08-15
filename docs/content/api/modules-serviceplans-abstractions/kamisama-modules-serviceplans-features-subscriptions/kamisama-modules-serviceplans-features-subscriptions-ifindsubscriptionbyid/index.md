# IFindSubscriptionById

<a id="ifindsubscriptionbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs#L24)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Interface`

## Description

Defines subscription lookup by `Guid` and returns related subscriber and plan identifiers from navigations.

## Declaration

```csharp
public interface IFindSubscriptionById : IFindByIdFeature<SubscriptionDto, Guid>;
```

## Example

```csharp
SubscriptionDto subscription = await findSubscriptionById.FindByIdAsync(subscriptionId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

