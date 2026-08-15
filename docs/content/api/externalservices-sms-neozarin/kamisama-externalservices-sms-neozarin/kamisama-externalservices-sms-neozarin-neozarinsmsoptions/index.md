# NeoZarinSmsOptions

<a id="neozarinsmsoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsOptions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsOptions.cs#L11)

Namespace: `KamiSama.ExternalServices.Sms.NeoZarin`

Kind: `Class`

## Description

Contains NeoZarin endpoint, credential, sender, and API settings. `IsValidForSms` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.

## Declaration

```csharp
public class NeoZarinSmsOptions
```

## Remarks

The current NeoZarin sender has a known inverted validation check: settings for which `IsValidForSms` returns are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.

## Example

```csharp
using KamiSama.ExternalServices.Sms.NeoZarin;

var options = new NeoZarinSmsOptions
{
    BaseUrl = "https://dashboard.neozarin.com",
    Username = Environment.GetEnvironmentVariable("NEOZARIN_USERNAME"),
    Password = Environment.GetEnvironmentVariable("NEOZARIN_PASSWORD"),
    SmsApiPath = "/api/json/sendgroupget",
    SmsSenderPhoneNumber = "+15551230000",
    SmsApi = Environment.GetEnvironmentVariable("NEOZARIN_SMS_API_KEY")
};

bool valuesArePresent = options.IsValidForSms();
// Known defect: the current internal sender throws when this value is true.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [IsValidForSms](method-isvalidforsms-38.md) | Returns when every endpoint, credential, sender, and API value required by the sender is non-null. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [BaseUrl](property-baseurl-14.md) | Gets or sets the NeoZarin service base URL. The built-in default uses plain HTTP; configure the provider&apos;s HTTPS URL when available. |
| [Password](property-password-20.md) | Gets or sets the NeoZarin password. Load this secret from protected configuration rather than source control. |
| [SmsApi](property-smsapi-30.md) | Gets or sets the NeoZarin SMS API identifier passed as the `api` parameter. Treat it as a secret and keep it out of source control. |
| [SmsApiPath](property-smsapipath-24.md) | Gets or sets the relative NeoZarin group-send endpoint path. Use it with the surrounding package APIs when composing application code. |
| [SmsSenderPhoneNumber](property-smssenderphonenumber-27.md) | Gets or sets the sender number passed as the NeoZarin `from` parameter. Use it with the surrounding package APIs when composing application code. |
| [Username](property-username-17.md) | Gets or sets the NeoZarin user name. Load credentials from protected configuration rather than source control. |

