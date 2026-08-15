# KavenegarSmsOptions

<a id="kavenegarsmsoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSmsOptions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSmsOptions.cs#L11)

Namespace: `KamiSama.ExternalServices.Sms.Kavenegar`

Kind: `Class`

## Description

Contains the Kavenegar sender number and API key. `IsValid` checks for an API key, but the current internal sender incorrectly throws when that check succeeds.

## Declaration

```csharp
public class KavenegarSmsOptions
```

## Remarks

The current Kavenegar sender has a known inverted validation check: settings for which `IsValid` returns are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.

## Example

```csharp
using KamiSama.ExternalServices.Sms.Kavenegar;

var options = new KavenegarSmsOptions
{
    SenderPhoneNumber = "+15551230000",
    ApiKey = Environment.GetEnvironmentVariable("KAVENEGAR_API_KEY")
};

bool apiKeyIsPresent = options.IsValid();
// Known defect: the current internal sender throws when this value is true.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [IsValid](method-isvalid-25.md) | Returns when `ApiKey` is non-null. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [ApiKey](property-apikey-17.md) | Gets or sets the Kavenegar API key. Load this secret from protected configuration rather than source control. |
| [SenderPhoneNumber](property-senderphonenumber-14.md) | Gets or sets the optional sender number supplied to Kavenegar. Use it with the surrounding package APIs when composing application code. |

