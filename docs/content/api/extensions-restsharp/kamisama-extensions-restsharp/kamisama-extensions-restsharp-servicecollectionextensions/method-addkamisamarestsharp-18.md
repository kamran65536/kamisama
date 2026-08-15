# AddKamiSamaRestSharp

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/ServiceCollectionExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/ServiceCollectionExtensions.cs#L18)

Type: `KamiSama.Extensions.RestSharp.ServiceCollectionExtensions`

Kind: `Method`

## Description

Registers `IRestClient` and `IRestBuilder` as scoped services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IServiceCollection AddKamiSamaRestSharp(this IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The service collection that receives the RestSharp registrations. |

## Returns

| Type | Description |
| --- | --- |
| `IServiceCollection` | The same service collection so additional registrations can be chained. |

## Example

No concise standalone example is available yet.

