# IsValid

[Back to KavenegarSmsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSmsOptions.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarSmsOptions.cs#L25)

Type: `KamiSama.ExternalServices.Sms.Kavenegar.KavenegarSmsOptions`

Kind: `Method`

## Description

Returns when `ApiKey` is non-null. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public bool IsValid();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `bool` | when an API key is present; otherwise, . |

## Remarks

The current internal Kavenegar sender incorrectly throws when this method returns .

## Example

No concise standalone example is available yet.

