# Subscriber

<a id="subscriber"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/Subscriber.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/Subscriber.cs#L6)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents a subscriber linked to an externally managed user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class Subscriber
```

## Example

```csharp
var subscriber = new Subscriber
{
    ExternalUserId = externalUserId, IsEnabled = true,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-26.md) | Gets or sets the creation timestamp of the subscriber. Use it with the surrounding package APIs when composing application code. |
| [ExternalUserId](property-externaluserid-16.md) | Gets or sets the identifier of the corresponding external customer. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-11.md) | Gets or sets the identifier of the subscriber. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-21.md) | Gets or sets a value indicating whether the subscriber may consume computation units. Use it with the surrounding package APIs when composing application code. |
| [Subscriptions](property-subscriptions-36.md) | Gets or sets the subscriptions owned by the subscriber. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-31.md) | Gets or sets the last update timestamp of the subscriber. Use it with the surrounding package APIs when composing application code. |

