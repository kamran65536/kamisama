# GetMd5Hex

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:60](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L60)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

returns MD5 hash for data. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string GetMd5Hex(this byte[] data);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | data to be hashed |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var data = new byte[] { 0x03, 0x44, 0x55, 0x12 };
var result = new byte[] { 0x19, 0x9b, 0xf2, 0xf3, 0x31, 0x0d, 0xd9, 0x4d, 0x24, 0x82, 0x0e, 0xc1, 0x25, 0x47, 0x8a, 0x83 };
```

