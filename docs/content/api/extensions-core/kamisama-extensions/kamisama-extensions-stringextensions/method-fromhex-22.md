# FromHex

[Back to StringExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/StringExtensions.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StringExtensions.cs#L22)

Type: `KamiSama.Extensions.StringExtensions`

Kind: `Method`

## Description

Converts hexadecimal string to byte array. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] FromHex(this string? hex);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `hex (extension receiver)` | `string?` | `-` | hexadecimal string |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | equivalent byte array |

## Example

```csharp
using KamiSama.Extensions;

var bytes = "0A FF".FromHex();
```

