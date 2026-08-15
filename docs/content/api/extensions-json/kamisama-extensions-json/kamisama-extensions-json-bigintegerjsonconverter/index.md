# BigIntegerJsonConverter

<a id="bigintegerjsonconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/BigIntegerJsonConverter.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/BigIntegerJsonConverter.cs#L9)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Converts `BigInteger` values to and from JSON, writing values as decimal strings. String tokens preserve arbitrary precision; numeric tokens are limited to the `decimal` range.

## Declaration

```csharp
public class BigIntegerJsonConverter : JsonConverter<BigInteger>
```

## Example

```csharp
using System.Numerics;
using System.Text.Json;
using KamiSama.Extensions.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

string json = JsonSerializer.Serialize(BigInteger.Parse("12345678901234567890"), options);
BigInteger value = JsonSerializer.Deserialize<BigInteger>(json, options);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-14.md) | Reads a `BigInteger` from a JSON string or number token. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-24.md) | Writes the `BigInteger` as a JSON string containing its decimal representation. Use it with the surrounding package APIs when composing application code. |

