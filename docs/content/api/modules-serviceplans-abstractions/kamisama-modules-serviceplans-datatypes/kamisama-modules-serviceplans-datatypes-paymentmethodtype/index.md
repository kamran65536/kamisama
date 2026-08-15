# PaymentMethodType

<a id="paymentmethodtype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/PaymentMethodType.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/DataTypes/PaymentMethodType.cs#L6)

Namespace: `KamiSama.Modules.ServicePlans.DataTypes`

Kind: `Enum`

## Description

Specifies a payment method category accepted by a subscription offer. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public enum PaymentMethodType
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Credit](enum-member-credit-11.md) | Indicates payment from an internal credit balance. Use it with the surrounding package APIs when composing application code. |
| [Crypto](enum-member-crypto-16.md) | Indicates payment using a supported cryptocurrency. Use it with the surrounding package APIs when composing application code. |
| [FiatGateway](enum-member-fiatgateway-21.md) | Indicates payment through a fiat payment provider. Use it with the surrounding package APIs when composing application code. |

