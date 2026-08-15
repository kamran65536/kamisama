# ToHex

[Back to ByteArrayExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ByteArrayExtensions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ByteArrayExtensions.cs#L15)

Type: `KamiSama.Extensions.ByteArrayExtensions`

Kind: `Method`

## Description

Converts the byte array to an uppercase hexadecimal string, optionally separating each byte. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string ToHex(this byte[] arr, string? separator = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `arr (extension receiver)` | `byte[]` | `-` | the byte array to be converted to hex |
| `separator` | `string?` | `null` | the separator to be used between hexadecimal digits |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
using KamiSama.Extensions;

var hex = new byte[] { 0x0A, 0xFF }.ToHex();
```

