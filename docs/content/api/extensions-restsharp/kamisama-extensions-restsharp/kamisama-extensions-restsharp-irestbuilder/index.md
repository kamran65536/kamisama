# IRestBuilder

<a id="irestbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L4)

Namespace: `KamiSama.Extensions.RestSharp`

Kind: `Interface`

## Description

Defines the contract for `IRestBuilder` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IRestBuilder
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddFile](method-addfile-10.md) | Runs the `AddFile` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddHeader](method-addheader-11.md) | Runs the `AddHeader` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddParameter](method-addparameter-7.md) | Runs the `AddParameter` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddQueryParameter](method-addqueryparameter-8.md) | Runs the `AddQueryParameter` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [AddUrlSegment](method-addurlsegment-9.md) | Runs the `AddUrlSegment` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-16.md) | Runs the `DeleteAsync` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [ForServiceUrl](method-forserviceurl-6.md) | Runs the `ForServiceUrl` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [GetAsync<T>](method-getasync-t-13.md) | Runs the `GetAsync<T>` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [GetAsyncWithoutResponse](method-getasyncwithoutresponse-17.md) | Runs the `GetAsyncWithoutResponse` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PostAsync<T>](method-postasync-t-14.md) | Runs the `PostAsync<T>` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PostAsyncWithoutResponse](method-postasyncwithoutresponse-18.md) | Runs the `PostAsyncWithoutResponse` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PutAsync<T>](method-putasync-t-15.md) | Runs the `PutAsync<T>` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [PutAsyncWithoutResponse](method-putasyncwithoutresponse-19.md) | Runs the `PutAsyncWithoutResponse` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |
| [WithBody](method-withbody-12.md) | Runs the `WithBody` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package. |

