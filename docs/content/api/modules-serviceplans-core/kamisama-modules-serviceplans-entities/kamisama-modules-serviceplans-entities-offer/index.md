# Offer

<a id="offer"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/Offer.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/Offer.cs#L9)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents an acquisition offer for a subscription plan. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class Offer
```

## Example

```csharp
var offer = new Offer
{
    Plan = plan, Name = "Standard monthly", Type = OfferType.Primary,
    StartsAt = null, EndsAt = null, IsEnabled = true,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Countries](property-countries-65.md) | Gets or sets the country restrictions belonging to the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-50.md) | Gets or sets the creation timestamp of the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [EndsAt](property-endsat-40.md) | Gets or sets the optional timestamp at which the subscription offer stops being available. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-14.md) | Gets or sets the identifier of the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-45.md) | Gets or sets a value indicating whether the subscription offer may be acquired. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-24.md) | Gets or sets the descriptive name of the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [PaymentMethods](property-paymentmethods-60.md) | Gets or sets the payment-method restrictions belonging to the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [Plan](property-plan-19.md) | Gets or sets the subscription plan made available by the offer. Use it with the surrounding package APIs when composing application code. |
| [StartsAt](property-startsat-35.md) | Gets or sets the optional timestamp at which the subscription offer becomes available. Use it with the surrounding package APIs when composing application code. |
| [Type](property-type-30.md) | Gets or sets the presentation type of the subscription offer. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-55.md) | Gets or sets the last update timestamp of the subscription offer. Use it with the surrounding package APIs when composing application code. |

