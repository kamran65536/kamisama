# IDeleteSubscriber

<a id="ideletesubscriber"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Features.cs#L20)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Interface`

## Description

Defines deletion of a subscriber by `Guid`. Core applies no ownership or deletion guard.

## Declaration

```csharp
public interface IDeleteSubscriber : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteSubscriber.DeleteAsync(subscriberId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

