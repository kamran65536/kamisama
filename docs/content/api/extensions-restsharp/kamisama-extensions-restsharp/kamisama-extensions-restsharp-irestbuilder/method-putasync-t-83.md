# PutAsync<T>

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:83](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L83)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Sends the current request with PUT and deserializes a successful response body as &lt;typeparamref name=&quot;T&quot;/&gt;. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<T> PutAsync<T>(CancellationToken cancellationToken);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | The expected response body type. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The token used to cancel the HTTP operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<T>` | The deserialized response body. |

## Example

No concise standalone example is available yet.

