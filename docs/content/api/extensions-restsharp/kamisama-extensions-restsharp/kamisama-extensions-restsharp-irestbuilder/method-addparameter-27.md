# AddParameter

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L27)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds a RestSharp parameter to the current request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder AddParameter(string name, object? value, ParameterType parameterType = ParameterType.GetOrPost, bool encode = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The parameter name. |
| `value` | `object?` | `-` | The parameter value. |
| `parameterType` | `ParameterType` | `ParameterType.GetOrPost` | The location or role of the parameter. |
| `encode` | `bool` | `true` | Whether RestSharp should URL-encode the value. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

