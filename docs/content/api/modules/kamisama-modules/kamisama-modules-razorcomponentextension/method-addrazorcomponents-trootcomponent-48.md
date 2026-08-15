# AddRazorComponents<TRootComponent>

[Back to RazorComponentExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RazorComponentModule.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorComponentModule.cs#L48)

Type: `KamiSama.Modules.RazorComponentExtension`

Kind: `Method`

## Description

Queues Razor component services and root-component endpoint mapping. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRazorComponents<TRootComponent>(this ExtendedWebApplicationBuilder builder, Action<RazorComponentsEndpointConventionBuilder>? configure = null);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TRootComponent` | The root component type to map. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<RazorComponentsEndpointConventionBuilder>?` | `null` | An optional endpoint convention callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddRazorComponents<App>();
```

