# AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:54](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L54)

Type: `KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions`

Kind: `Method`

## Description

Scans the assemblies containing both marker types and applies automatic injection attributes from each assembly. Use this overload when attributed implementations are split across two known assemblies.

## Declaration

```csharp
public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TAssemblyType1` | A type contained in the first assembly to scan. |
| `TAssemblyType2` | A type contained in the second assembly to scan. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The service collection that receives registrations from discovered attributes. |

## Returns

| Type | Description |
| --- | --- |
| `IServiceCollection` | The same service collection so additional registrations can be chained. |

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

services.AutoAddDependenciesFrom<Program>();
```

