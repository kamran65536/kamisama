# AutoAddDependenciesFrom<TAssemblyType>

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L44)

Type: `KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions`

Kind: `Method`

## Description

Scans the assembly containing &lt;typeparamref name=&quot;TAssemblyType&quot;/&gt; and applies automatic injection attributes. Use a marker type from the assembly whose attributed implementations should be registered.

## Declaration

```csharp
public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType>(this IServiceCollection services);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TAssemblyType` | A type contained in the assembly to scan. |

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

