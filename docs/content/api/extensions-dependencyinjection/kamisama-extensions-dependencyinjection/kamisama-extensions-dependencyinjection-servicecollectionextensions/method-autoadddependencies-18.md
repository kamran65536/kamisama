# AutoAddDependencies

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L18)

Type: `KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions`

Kind: `Method`

## Description

Scans the selected assemblies and applies every `AutoInjectAttributeBase` found on their declared types. When no assemblies are supplied, all assemblies currently loaded in the application domain are scanned.

## Declaration

```csharp
public static IServiceCollection AutoAddDependencies(this IServiceCollection services, params Assembly[]? assemblies);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The service collection that receives registrations from discovered attributes. |
| `assemblies` | `Assembly[]?` | `-` | The assemblies to scan, or or an empty array to scan all currently loaded assemblies. |

## Returns

| Type | Description |
| --- | --- |
| `IServiceCollection` | The same service collection so additional registrations can be chained. |

## Example

No concise standalone example is available yet.

