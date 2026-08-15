# IRestBuilder

<a id="irestbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L9)

Namespace: `KamiSama.Extensions.RestSharp`

Kind: `Interface`

## Description

Builds and executes one RestSharp request through a fluent API. Start each request with `ForServiceUrl`, add the required request data, and then call an HTTP verb method.

## Declaration

```csharp
public interface IRestBuilder
```

## Example

```csharp
using KamiSama.Extensions.RestSharp;

ProductDto product = await restBuilder
    .ForServiceUrl("https://api.example.com", "products/{id}")
    .AddUrlSegment("id", 42)
    .AddHeader("X-Correlation-Id", correlationId)
    .GetAsync<ProductDto>(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddFile](method-addfile-48.md) | Adds an in-memory file to the current multipart request. Use it with the surrounding package APIs when composing application code. |
| [AddHeader](method-addheader-55.md) | Adds an HTTP header to the current request. Use it with the surrounding package APIs when composing application code. |
| [AddParameter](method-addparameter-27.md) | Adds a RestSharp parameter to the current request. Use it with the surrounding package APIs when composing application code. |
| [AddQueryParameter](method-addqueryparameter-33.md) | Adds the public properties of an object as query parameters on the current request. Use it with the surrounding package APIs when composing application code. |
| [AddUrlSegment](method-addurlsegment-41.md) | Adds a value for a named URL segment in the current request path. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-89.md) | Sends the current request with DELETE and completes when the remote service returns a successful response. Use it with the surrounding package APIs when composing application code. |
| [ForServiceUrl](method-forserviceurl-18.md) | Starts a request by combining a service base URL with a relative resource path. Calling this method replaces any request previously configured on this builder. |
| [GetAsync<T>](method-getasync-t-69.md) | Sends the current request with GET and deserializes a successful response body as &lt;typeparamref name=&quot;T&quot;/&gt;. Use it with the surrounding package APIs when composing application code. |
| [GetAsyncWithoutResponse](method-getasyncwithoutresponse-95.md) | Sends the current request with GET without deserializing a response body. Use it with the surrounding package APIs when composing application code. |
| [PostAsync<T>](method-postasync-t-76.md) | Sends the current request with POST and deserializes a successful response body as &lt;typeparamref name=&quot;T&quot;/&gt;. Use it with the surrounding package APIs when composing application code. |
| [PostAsyncWithoutResponse](method-postasyncwithoutresponse-101.md) | Sends the current request with POST without deserializing a response body. Use it with the surrounding package APIs when composing application code. |
| [PutAsync<T>](method-putasync-t-83.md) | Sends the current request with PUT and deserializes a successful response body as &lt;typeparamref name=&quot;T&quot;/&gt;. Use it with the surrounding package APIs when composing application code. |
| [PutAsyncWithoutResponse](method-putasyncwithoutresponse-107.md) | Sends the current request with PUT without deserializing a response body. Use it with the surrounding package APIs when composing application code. |
| [WithBody](method-withbody-62.md) | Adds an object body with the specified content type to the current request. Use it with the surrounding package APIs when composing application code. |

