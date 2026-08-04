# HierarchicalJsonConverter<T>

<a id="hierarchicaljsonconverter-t"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L9)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Generic Json Hierarchical Json Converter. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class HierarchicalJsonConverter<T> : JsonConverter<T>
		where T : class
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Fields

| Member | Description |
| --- | --- |
| [typeMap](field-typemap-18.md) | map from discriminator key value to child type. Use it with the surrounding package APIs when composing application code. |

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-74.md) | Reads a &lt;typeparamref name=&quot;T&quot;/&gt; from an input json and converts based on key. Use it with the surrounding package APIs when composing application code. |
| [Register](method-register-40.md) | Registers a child type to a key. Use it with the surrounding package APIs when composing application code. |
| [Register<TChild>](method-register-tchild-24.md) | Registers a child type to a key. Use it with the surrounding package APIs when composing application code. |
| [Register<TChild>](method-register-tchild-30.md) | Registers a child type based on default discriminator value. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-65.md) | Writes a channel configuration (basically this method simply calls JsonSerializer.Serialize method). Use it with the surrounding package APIs when composing application code. |

