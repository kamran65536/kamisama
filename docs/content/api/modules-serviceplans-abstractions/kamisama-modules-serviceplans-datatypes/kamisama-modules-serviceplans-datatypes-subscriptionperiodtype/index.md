# SubscriptionPeriodType

<a id="subscriptionperiodtype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/SubscriptionPeriodType.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/SubscriptionPeriodType.cs#L6)

Namespace: `KamiSama.Modules.ServicePlans.DataTypes`

Kind: `Enum`

## Description

Specifies the period over which a subscription allowance is measured. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public enum SubscriptionPeriodType
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Daily](enum-member-daily-11.md) | Indicates that the allowance resets each day. Use it with the surrounding package APIs when composing application code. |
| [Monthly](enum-member-monthly-16.md) | Indicates that the allowance resets each month. Use it with the surrounding package APIs when composing application code. |
| [Unlimited](enum-member-unlimited-21.md) | Indicates that the allowance remains valid for the subscription lifetime without a recurring reset. Use it with the surrounding package APIs when composing application code. |

