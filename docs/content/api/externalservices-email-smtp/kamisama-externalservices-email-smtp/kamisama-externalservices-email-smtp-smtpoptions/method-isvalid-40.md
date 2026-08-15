# IsValid

[Back to SmtpOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpOptions.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpOptions.cs#L40)

Type: `KamiSama.ExternalServices.Email.Smtp.SmtpOptions`

Kind: `Method`

## Description

Returns when all required string settings are non-null and `Port` is nonzero. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public bool IsValid();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `bool` | when the configured values pass these presence checks; otherwise, . |

## Remarks

The current internal SMTP sender incorrectly throws when this method returns .

## Example

No concise standalone example is available yet.

