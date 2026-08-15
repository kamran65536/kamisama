# GetSha1Hex

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:108](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L108)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

Encodes the string and returns its SHA-1 hash as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string GetSha1Hex(this string data, Encoding? encoding = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `string` | `-` | data to be hashed |
| `encoding` | `Encoding?` | `null` | encoding used to convert string to byte array, default is UTF8 |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var data = new byte[] { 0x03, 0x44, 0x55, 0x12 };
var result = new byte[] { 0xbf, 0xfb, 0xe0, 0x75, 0xa2, 0x2b, 0x4a, 0x97, 0x2d, 0xfa, 0x97, 0x6e, 0x07, 0x47, 0x8c, 0x43, 0xbe, 0xfa, 0xfc, 0xad };
```

