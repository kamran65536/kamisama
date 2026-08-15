# ForServiceUrl

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L18)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Starts a request by combining a service base URL with a relative resource path. Calling this method replaces any request previously configured on this builder.

## Declaration

```csharp
IRestBuilder ForServiceUrl(string baseUrl, string relativePath);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `baseUrl` | `string` | `-` | The absolute base URL of the remote service. |
| `relativePath` | `string` | `-` | The path of the resource relative to the service URL. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

