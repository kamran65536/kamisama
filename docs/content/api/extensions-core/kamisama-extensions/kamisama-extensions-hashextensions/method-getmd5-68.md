# GetMd5

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:68](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L68)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

returns MD5 hash for data. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] GetMd5(this string data, Encoding? encoding = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `string` | `-` | data to be hashed |
| `encoding` | `Encoding?` | `null` | encoding used to convert string to byte array, default is UTF8 |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var data = new byte[] { 0x03, 0x44, 0x55, 0x12 };
var result = new byte[] { 0x19, 0x9b, 0xf2, 0xf3, 0x31, 0x0d, 0xd9, 0x4d, 0x24, 0x82, 0x0e, 0xc1, 0x25, 0x47, 0x8a, 0x83 };
```

