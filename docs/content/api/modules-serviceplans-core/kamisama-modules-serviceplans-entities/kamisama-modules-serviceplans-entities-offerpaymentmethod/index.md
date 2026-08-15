# OfferPaymentMethod

<a id="offerpaymentmethod"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/OfferPaymentMethod.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/OfferPaymentMethod.cs#L9)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents a payment method accepted by a subscription offer. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class OfferPaymentMethod
```

## Example

```csharp
offer.PaymentMethods.Add(new OfferPaymentMethod
{
    Offer = offer, Type = PaymentMethodType.FiatGateway, CurrencyCode = "USD",
    ExternalProviderId = "primary", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-41.md) | Gets or sets the creation timestamp of the offer payment method. Use it with the surrounding package APIs when composing application code. |
| [CurrencyCode](property-currencycode-29.md) | Gets or sets the optional currency code required by the payment method. Use it with the surrounding package APIs when composing application code. |
| [ExternalProviderId](property-externalproviderid-35.md) | Gets or sets the optional external payment-provider identifier. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-14.md) | Gets or sets the identifier of the offer payment method. Use it with the surrounding package APIs when composing application code. |
| [Offer](property-offer-19.md) | Gets or sets the subscription offer that accepts the payment method. Use it with the surrounding package APIs when composing application code. |
| [Type](property-type-24.md) | Gets or sets the payment method category. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-46.md) | Gets or sets the last update timestamp of the offer payment method. Use it with the surrounding package APIs when composing application code. |

