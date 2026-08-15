# AddHeader

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:55](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L55)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds an HTTP header to the current request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder AddHeader(string name, string value);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The header name. |
| `value` | `string` | `-` | The header value. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

