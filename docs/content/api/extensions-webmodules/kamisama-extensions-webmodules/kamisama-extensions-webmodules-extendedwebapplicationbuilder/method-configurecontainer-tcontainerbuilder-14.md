# ConfigureContainer<TContainerBuilder>

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L14)

Type: `KamiSama.Extensions.WebModules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Runs the `ConfigureContainer<TContainerBuilder>` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null)
    where TContainerBuilder : notnull;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TContainerBuilder` | The `TContainerBuilder` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `factory` | `IServiceProviderFactory<TContainerBuilder>` | `-` | The `factory` value passed to this member. |
| `configure` | `Action<TContainerBuilder>?` | `null` | The `configure` value passed to this member. |

## Example

No concise standalone example is available yet.

