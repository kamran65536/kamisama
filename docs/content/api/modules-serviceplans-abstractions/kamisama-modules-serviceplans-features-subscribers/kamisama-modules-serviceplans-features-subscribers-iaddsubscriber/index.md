# IAddSubscriber

<a id="iaddsubscriber"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs#L12)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Interface`

## Description

Defines subscriber creation for an externally managed user. Core performs a race-prone duplicate read and does not authenticate or validate ownership of the supplied external identifier.

## Declaration

```csharp
public interface IAddSubscriber : IAddFeature<AddSubscriberRequest, SubscriberDto>;
```

## Example

```csharp
SubscriberDto subscriber = await addSubscriber.AddAsync(
    new AddSubscriberRequest(externalUserId, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

