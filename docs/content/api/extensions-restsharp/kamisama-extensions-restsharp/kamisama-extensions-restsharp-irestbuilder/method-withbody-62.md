# WithBody

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:62](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L62)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds an object body with the specified content type to the current request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder WithBody(object body, string contentType = "application/json");
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `body` | `object` | `-` | The object RestSharp serializes as the request body. |
| `contentType` | `string` | `"application/json"` | The media type of the request body. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

