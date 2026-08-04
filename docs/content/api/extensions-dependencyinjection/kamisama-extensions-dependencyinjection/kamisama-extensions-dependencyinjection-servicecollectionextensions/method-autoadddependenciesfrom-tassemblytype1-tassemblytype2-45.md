# AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L45)

Type: `KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions`

Kind: `Method`

## Description

Automatically adds dependency injections using `AutoInjectAttribute`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TAssemblyType1` | The `TAssemblyType1` generic type argument. |
| `TAssemblyType2` | The `TAssemblyType2` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The `services` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IServiceCollection` | Returns a `IServiceCollection` value. |

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

services.AutoAddDependenciesFrom<Program>();
```

