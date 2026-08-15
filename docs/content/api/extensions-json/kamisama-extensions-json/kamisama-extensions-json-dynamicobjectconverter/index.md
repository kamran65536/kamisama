# DynamicObjectConverter

<a id="dynamicobjectconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/DynamicObjectConverter.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/DynamicObjectConverter.cs#L7)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Converts JSON values to dynamic CLR object graphs and serializes runtime object values back to JSON. Objects become `ExpandoObject` instances, while arrays and scalar values use their corresponding CLR shapes.

## Declaration

```csharp
public class DynamicObjectConverter : JsonConverter<object>
```

## Example

```csharp
using System.Collections.Generic;
using System.Text.Json;
using KamiSama.Extensions.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new DynamicObjectConverter());

var value = JsonSerializer.Deserialize<object>("{\"name\":\"KamiSama\"}", options);
var properties = (IDictionary<string, object?>)value!;
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-17.md) | Reads a JSON value and converts it to an `ExpandoObject`, array, scalar value, or . Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-12.md) | Serializes the value using its runtime type. Use it with the surrounding package APIs when composing application code. |

