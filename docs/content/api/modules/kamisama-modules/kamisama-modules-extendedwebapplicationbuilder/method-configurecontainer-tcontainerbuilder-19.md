# ConfigureContainer<TContainerBuilder>

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L19)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Delegates service-provider factory and optional container configuration to the underlying host builder. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null)
    where TContainerBuilder : notnull;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TContainerBuilder` | The container-builder type used by the service-provider factory. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `factory` | `IServiceProviderFactory<TContainerBuilder>` | `-` | The factory that creates the service provider. |
| `configure` | `Action<TContainerBuilder>?` | `null` | An optional callback that configures the container builder. |

## Example

No concise standalone example is available yet.

