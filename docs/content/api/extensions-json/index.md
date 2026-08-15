# KamiSama.Extensions.Json

[Back to package index](../index.md)

Version: `10.0.0`

## Description

System.Text.Json convenience extensions for serialization, deserialization, dynamic JSON object graphs, and converter registration. Includes converters for BigInteger, hexadecimal byte arrays, TimeSpan, and discriminator-based polymorphic types.

## How to use

```shell
dotnet add package KamiSama.Extensions.Json --version 10.0.0
```

Use `KamiSama.Extensions` for serialization helpers and `KamiSama.Extensions.Json` for converter types. Register converters on the `JsonSerializerOptions` instance used by your application:

```csharp
using KamiSama.Extensions;
using KamiSama.Extensions.Json;

var options = new JsonSerializerOptions()
    .AddHexByteConverter()
    .AddTimeSpanJsonConverter();

options.Converters.Add(new BigIntegerJsonConverter());
options.Converters.Add(new DynamicObjectConverter());
```

For polymorphic deserialization, mark one base-type property with `JsonHirerarchyDiscriminatorAttribute`, register each derived type with `HierarchicalJsonConverter<T>.Register`, and then call `AddHierarchicalConverter<T>()` on the same options instance.

## Namespaces

- [KamiSama.Extensions](kamisama-extensions/index.md) (1 types)
- [KamiSama.Extensions.Json](kamisama-extensions-json/index.md) (6 types)

## Types

- [KamiSama.Extensions.JsonSerializationExtensions](kamisama-extensions/kamisama-extensions-jsonserializationextensions/index.md) - Provides extensions for JSON serialization, deserialization, dynamic conversion, and converter registration. The registration helpers mutate and return the supplied `JsonSerializerOptions` instance.
- [KamiSama.Extensions.Json.BigIntegerJsonConverter](kamisama-extensions-json/kamisama-extensions-json-bigintegerjsonconverter/index.md) - Converts `BigInteger` values to and from JSON, writing values as decimal strings. String tokens preserve arbitrary precision; numeric tokens are limited to the `decimal` range.
- [KamiSama.Extensions.Json.DynamicObjectConverter](kamisama-extensions-json/kamisama-extensions-json-dynamicobjectconverter/index.md) - Converts JSON values to dynamic CLR object graphs and serializes runtime object values back to JSON. Objects become `ExpandoObject` instances, while arrays and scalar values use their corresponding CLR shapes.
- [KamiSama.Extensions.Json.HexByteArrayJsonConverter](kamisama-extensions-json/kamisama-extensions-json-hexbytearrayjsonconverter/index.md) - Converts byte arrays to and from hexadecimal JSON strings. Use it when binary values should be represented as hexadecimal text instead of Base64.
- [KamiSama.Extensions.Json.HierarchicalJsonConverter<T>](kamisama-extensions-json/kamisama-extensions-json-hierarchicaljsonconverter-t/index.md) - Deserializes instances of a base type as registered derived types selected by a discriminator property. Mark the base type&apos;s discriminator property and register every supported discriminator value before deserialization.
- [KamiSama.Extensions.Json.JsonHirerarchyDiscriminatorAttribute](kamisama-extensions-json/kamisama-extensions-json-jsonhirerarchydiscriminatorattribute/index.md) - Marks the property used by `HierarchicalJsonConverter{T}` as the polymorphic type discriminator. Apply it to exactly one public property on the base type.
- [KamiSama.Extensions.Json.TimeSpanJsonConverter](kamisama-extensions-json/kamisama-extensions-json-timespanjsonconverter/index.md) - Converts `TimeSpan` values to and from their standard JSON string representation. Use it when an application needs this package&apos;s explicit string-format compatibility behavior.
