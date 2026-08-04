# KamiSama.Extensions.RestSharp

[Back to package index](../index.md)

Version: `10.0.10`

## Description

RestSharp registration and request helpers for KamiSama HTTP client integrations. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Extensions.RestSharp --version 10.0.10
```

## Namespaces

- [KamiSama.Extensions.RestSharp](kamisama-extensions-restsharp/index.md) (3 types)
- [KamiSama.Extensions.RestSharp.Exceptions](kamisama-extensions-restsharp-exceptions/index.md) (2 types)

## Types

- [KamiSama.Extensions.RestSharp.IRestBuilder](kamisama-extensions-restsharp/kamisama-extensions-restsharp-irestbuilder/index.md) - Defines the contract for `IRestBuilder` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Extensions.RestSharp.RestBuilder](kamisama-extensions-restsharp/kamisama-extensions-restsharp-restbuilder/index.md) - Provides the `RestBuilder` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Extensions.RestSharp.ServiceCollectionExtensions](kamisama-extensions-restsharp/kamisama-extensions-restsharp-servicecollectionextensions/index.md) - Provides the `ServiceCollectionExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Extensions.RestSharp.Exceptions.InvalidResponseFromServerException](kamisama-extensions-restsharp-exceptions/kamisama-extensions-restsharp-exceptions-invalidresponsefromserverexception/index.md) - This is a UI response exception and should not be used in backend. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Extensions.RestSharp.Exceptions.RequestTimedOutException](kamisama-extensions-restsharp-exceptions/kamisama-extensions-restsharp-exceptions-requesttimedoutexception/index.md) - This is a UI response exception and should not be used in backend. Use it with the surrounding package APIs when composing application code.
