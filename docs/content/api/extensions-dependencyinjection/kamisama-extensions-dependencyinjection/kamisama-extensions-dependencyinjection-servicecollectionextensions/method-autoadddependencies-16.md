# AutoAddDependencies

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L16)

Type: `KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions`

Kind: `Method`

## Description

Automatically adds dependency injections using `AutoInjectAttribute`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IServiceCollection AutoAddDependencies(this IServiceCollection services, params Assembly[]? assemblies);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The `services` value passed to this member. |
| `assemblies` | `Assembly[]?` | `-` | list of assemblies to search, null means all assemblies |

## Returns

| Type | Description |
| --- | --- |
| `IServiceCollection` | Returns a `IServiceCollection` value. |

## Example

No concise standalone example is available yet.

