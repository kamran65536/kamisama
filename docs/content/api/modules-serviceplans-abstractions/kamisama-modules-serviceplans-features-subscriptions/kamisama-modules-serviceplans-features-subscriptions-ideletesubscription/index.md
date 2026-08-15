# IDeleteSubscription

<a id="ideletesubscription"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs#L20)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Interface`

## Description

Defines deletion of a subscription by `Guid`. Core applies no ownership or lifecycle guard.

## Declaration

```csharp
public interface IDeleteSubscription : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteSubscription.DeleteAsync(subscriptionId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

