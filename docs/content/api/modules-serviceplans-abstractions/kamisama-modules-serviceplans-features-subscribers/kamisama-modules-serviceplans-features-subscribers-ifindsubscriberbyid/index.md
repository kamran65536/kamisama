# IFindSubscriberById

<a id="ifindsubscriberbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs#L24)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Interface`

## Description

Defines subscriber lookup by `Guid`.

## Declaration

```csharp
public interface IFindSubscriberById : IFindByIdFeature<SubscriberDto, Guid>;
```

## Example

```csharp
SubscriberDto subscriber = await findSubscriberById.FindByIdAsync(subscriberId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

