# FromBase64

[Back to StringExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/StringExtensions.cs:52](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StringExtensions.cs#L52)

Type: `KamiSama.Extensions.StringExtensions`

Kind: `Method`

## Description

Converts base 64 string to byte array. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] FromBase64(this string base64);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `base64 (extension receiver)` | `string` | `-` | base 64 string |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | byte array |

## Example

```csharp
using KamiSama.Extensions;

var bytes = "AQID".FromBase64();
```

