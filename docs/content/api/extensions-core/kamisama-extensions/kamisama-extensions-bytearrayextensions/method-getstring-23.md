# GetString

[Back to ByteArrayExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ByteArrayExtensions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ByteArrayExtensions.cs#L23)

Type: `KamiSama.Extensions.ByteArrayExtensions`

Kind: `Method`

## Description

Decodes the byte array using the specified encoding, or UTF-8 when no encoding is supplied. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string GetString(this byte[] arr, Encoding? encoding = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `arr (extension receiver)` | `byte[]` | `-` | the byte array to be decoded to string |
| `encoding` | `Encoding?` | `null` | the encoding, null means default encoding (Encoding.UTF8) |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
using KamiSama.Extensions;

var text = new byte[] { 72, 105 }.GetString();
```

