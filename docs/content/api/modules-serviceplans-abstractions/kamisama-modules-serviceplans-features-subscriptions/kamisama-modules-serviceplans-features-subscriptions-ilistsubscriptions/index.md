# IListSubscriptions

<a id="ilistsubscriptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Features.cs#L8)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Interface`

## Description

Defines paged subscription listing by subscriber, plan, and status set. Core recognizes `status`, `startsat`, `endsat`, and `updatedat` ordering tokens.

## Declaration

```csharp
public interface IListSubscriptions : IListFeature<SubscriptionDto, SubscriptionSearchModel>;
```

## Example

```csharp
PagedResult<SubscriptionDto> subscriptions = await listSubscriptions.ListAsync(
    new SubscriptionSearchModel(1, 20, subscriberId, null, [SubscriptionStatus.Active], "startsat"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

