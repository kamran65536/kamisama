# IListSubscribers

<a id="ilistsubscribers"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs#L8)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Interface`

## Description

Defines paged subscriber listing by external user identifier and enabled state. Core recognizes `externaluserid`, `createdat`, and `updatedat` ordering tokens.

## Declaration

```csharp
public interface IListSubscribers : IListFeature<SubscriberDto, SubscriberSearchModel>;
```

## Example

```csharp
PagedResult<SubscriberDto> subscribers = await listSubscribers.ListAsync(
    new SubscriberSearchModel(1, 20, externalUserId, true, "updatedat"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

