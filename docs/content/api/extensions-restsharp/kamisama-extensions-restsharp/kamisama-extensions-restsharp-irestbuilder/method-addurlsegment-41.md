# AddUrlSegment

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L41)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds a value for a named URL segment in the current request path. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder AddUrlSegment(string name, object? value, bool encode = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The URL segment name. |
| `value` | `object?` | `-` | The value that replaces the named segment. |
| `encode` | `bool` | `true` | Whether RestSharp should URL-encode the value. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

