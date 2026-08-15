# IsValidForSms

[Back to NeoZarinSmsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsOptions.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsOptions.cs#L38)

Type: `KamiSama.ExternalServices.Sms.NeoZarin.NeoZarinSmsOptions`

Kind: `Method`

## Description

Returns when every endpoint, credential, sender, and API value required by the sender is non-null. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public bool IsValidForSms();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `bool` | when all required SMS settings are present; otherwise, . |

## Remarks

The current internal NeoZarin sender incorrectly throws when this method returns .

## Example

No concise standalone example is available yet.

