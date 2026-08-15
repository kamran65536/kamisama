# SubscriptionStatus

<a id="subscriptionstatus"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/SubscriptionStatus.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/SubscriptionStatus.cs#L6)

Namespace: `KamiSama.Modules.ServicePlans.DataTypes`

Kind: `Enum`

## Description

Specifies the state of a subscription. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public enum SubscriptionStatus
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Active](enum-member-active-11.md) | Indicates that the subscription is available for service usage. Use it with the surrounding package APIs when composing application code. |
| [Cancelled](enum-member-cancelled-26.md) | Indicates that the subscription was cancelled before its configured end. Use it with the surrounding package APIs when composing application code. |
| [Expired](enum-member-expired-21.md) | Indicates that the subscription has reached its configured end. Use it with the surrounding package APIs when composing application code. |
| [Suspended](enum-member-suspended-16.md) | Indicates that the subscription has been temporarily suspended. Use it with the surrounding package APIs when composing application code. |

