# OfferCountry

<a id="offercountry"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/OfferCountry.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/OfferCountry.cs#L8)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents a country in which a subscription offer may be acquired. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class OfferCountry
```

## Example

```csharp
offer.Countries.Add(new OfferCountry
{
    Offer = offer, CountryCode = "US", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CountryCode](property-countrycode-23.md) | Gets or sets the ISO 3166-1 alpha-2 country code. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-29.md) | Gets or sets the creation timestamp of the offer country restriction. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-13.md) | Gets or sets the identifier of the offer country restriction. Use it with the surrounding package APIs when composing application code. |
| [Offer](property-offer-18.md) | Gets or sets the subscription offer available in the country. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-34.md) | Gets or sets the last update timestamp of the offer country restriction. Use it with the surrounding package APIs when composing application code. |

