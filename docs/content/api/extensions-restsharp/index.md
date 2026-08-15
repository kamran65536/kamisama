# KamiSama.Extensions.RestSharp

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Fluent RestSharp request construction and dependency injection registration for HTTP integrations. Build GET, POST, PUT, and DELETE requests with parameters, headers, URL segments, files, or JSON bodies, then deserialize successful responses.

## How to use

```shell
dotnet add package KamiSama.Extensions.RestSharp --version 10.0.0
```

Register an `HttpClient` before adding the RestSharp services. Inject `IRestBuilder`, start each request with `ForServiceUrl`, add request data, and then call the required HTTP verb:

```csharp
using KamiSama.Extensions.RestSharp;

services.AddHttpClient();
services.AddKamiSamaRestSharp();

ProductDto product = await restBuilder
    .ForServiceUrl("https://api.example.com", "products/{id}")
    .AddUrlSegment("id", 42)
    .GetAsync<ProductDto>(cancellationToken);
```

`IRestBuilder` is scoped and stores the current request. Call `ForServiceUrl` before configuring every request, and do not share one builder across concurrent operations.

## Namespaces

- [KamiSama.Extensions.RestSharp](kamisama-extensions-restsharp/index.md) (2 types)
- [KamiSama.Extensions.RestSharp.Exceptions](kamisama-extensions-restsharp-exceptions/index.md) (2 types)

## Types

- [KamiSama.Extensions.RestSharp.IRestBuilder](kamisama-extensions-restsharp/kamisama-extensions-restsharp-irestbuilder/index.md) - Builds and executes one RestSharp request through a fluent API. Start each request with `ForServiceUrl`, add the required request data, and then call an HTTP verb method.
- [KamiSama.Extensions.RestSharp.ServiceCollectionExtensions](kamisama-extensions-restsharp/kamisama-extensions-restsharp-servicecollectionextensions/index.md) - Registers the RestSharp client and fluent request builder used by this package. Call `AddKamiSamaRestSharp` during service configuration after making `HttpClient` available from dependency injection.
- [KamiSama.Extensions.RestSharp.Exceptions.InvalidResponseFromServerException](kamisama-extensions-restsharp-exceptions/kamisama-extensions-restsharp-exceptions-invalidresponsefromserverexception/index.md) - Represents an invalid response received by a UI client from a remote server. This exception uses the application-specific status code `-2` and is not intended for backend HTTP responses.
- [KamiSama.Extensions.RestSharp.Exceptions.RequestTimedOutException](kamisama-extensions-restsharp-exceptions/kamisama-extensions-restsharp-exceptions-requesttimedoutexception/index.md) - Represents a remote request timeout reported to a UI client. This exception uses the application-specific status code `-1` and is not intended for backend HTTP responses.
