# ServiceCollectionExtensions

<a id="servicecollectionextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/ServiceCollectionExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/ServiceCollectionExtensions.cs#L11)

Namespace: `KamiSama.Extensions.RestSharp`

Kind: `Class`

## Description

Registers the RestSharp client and fluent request builder used by this package. Call `AddKamiSamaRestSharp` during service configuration after making `HttpClient` available from dependency injection.

## Declaration

```csharp
public static class ServiceCollectionExtensions
```

## Example

```csharp
using KamiSama.Extensions.RestSharp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
services.AddKamiSamaRestSharp();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddKamiSamaRestSharp](method-addkamisamarestsharp-18.md) | Registers `IRestClient` and `IRestBuilder` as scoped services. Use it with the surrounding package APIs when composing application code. |

