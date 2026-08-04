# RestBuilder

<a id="restbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/RestBuilder.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/RestBuilder.cs#L8)

Namespace: `KamiSama.Extensions.RestSharp`

Kind: `Class`

## Description

Provides the `RestBuilder` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class RestBuilder(IRestClient client) : IRestBuilder
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/RestBuilder.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class RestBuilder(IRestClient client) : IRestBuilder
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `client` | `IRestClient` | `-` | The `client` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddFile](method-addfile-42.md) | Runs the `AddFile` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddHeader](method-addheader-36.md) | Runs the `AddHeader` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddParameter](method-addparameter-29.md) | Runs the `AddParameter` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddQueryParameter](method-addqueryparameter-20.md) | Runs the `AddQueryParameter` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddUrlSegment](method-addurlsegment-26.md) | Runs the `AddUrlSegment` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-106.md) | Runs the `DeleteAsync` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [ForServiceUrl](method-forserviceurl-13.md) | Runs the `ForServiceUrl` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [GetAsync<T>](method-getasync-t-55.md) | Runs the `GetAsync<T>` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [GetAsyncWithoutResponse](method-getasyncwithoutresponse-117.md) | Runs the `GetAsyncWithoutResponse` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PostAsync<T>](method-postasync-t-89.md) | Runs the `PostAsync<T>` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PostAsyncWithoutResponse](method-postasyncwithoutresponse-129.md) | Runs the `PostAsyncWithoutResponse` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PutAsync<T>](method-putasync-t-72.md) | Runs the `PutAsync<T>` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PutAsyncWithoutResponse](method-putasyncwithoutresponse-140.md) | Runs the `PutAsyncWithoutResponse` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |
| [WithBody](method-withbody-48.md) | Runs the `WithBody` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package. |

