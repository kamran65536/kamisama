# HexByteArrayJsonConverter

<a id="hexbytearrayjsonconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/HexByteArrayJsonConverter.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HexByteArrayJsonConverter.cs#L7)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Converts byte arrays to and from hexadecimal JSON strings. Use it when binary values should be represented as hexadecimal text instead of Base64.

## Declaration

```csharp
public class HexByteArrayJsonConverter : JsonConverter<byte[]>
```

## Example

```csharp
using System.Text.Json;
using KamiSama.Extensions;

var options = new JsonSerializerOptions().AddHexByteConverter();
string json = JsonSerializer.Serialize(new byte[] { 0xCA, 0xFE }, options); // "CAFE"
byte[]? value = JsonSerializer.Deserialize<byte[]>(json, options);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-16.md) | Reads a hexadecimal JSON string as a byte array, or returns for a null token. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-30.md) | Writes the byte array as an uppercase hexadecimal JSON string. Use it with the surrounding package APIs when composing application code. |

