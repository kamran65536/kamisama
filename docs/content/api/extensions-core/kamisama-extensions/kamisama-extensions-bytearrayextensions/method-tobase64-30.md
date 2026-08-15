# ToBase64

[Back to ByteArrayExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ByteArrayExtensions.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ByteArrayExtensions.cs#L30)

Type: `KamiSama.Extensions.ByteArrayExtensions`

Kind: `Method`

## Description

Converts the byte array to its Base64 string representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string ToBase64(this byte[] arr);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `arr (extension receiver)` | `byte[]` | `-` | the byte array to be converted to base 64 |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
using KamiSama.Extensions;

var text = new byte[] { 1, 2, 3 }.ToBase64();
```

