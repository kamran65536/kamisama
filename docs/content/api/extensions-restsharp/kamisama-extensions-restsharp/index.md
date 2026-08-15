# KamiSama.Extensions.RestSharp

[Back to KamiSama.Extensions.RestSharp](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [IRestBuilder](kamisama-extensions-restsharp-irestbuilder/index.md) | Interface | Builds and executes one RestSharp request through a fluent API. Start each request with `ForServiceUrl`, add the required request data, and then call an HTTP verb method. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L9) |
| [ServiceCollectionExtensions](kamisama-extensions-restsharp-servicecollectionextensions/index.md) | Class | Registers the RestSharp client and fluent request builder used by this package. Call `AddKamiSamaRestSharp` during service configuration after making `HttpClient` available from dependency injection. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/ServiceCollectionExtensions.cs#L11) |
