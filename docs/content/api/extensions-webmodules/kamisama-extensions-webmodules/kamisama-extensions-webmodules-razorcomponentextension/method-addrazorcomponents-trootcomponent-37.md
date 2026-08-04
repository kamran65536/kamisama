# AddRazorComponents<TRootComponent>

[Back to RazorComponentExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RazorComponentModule.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RazorComponentModule.cs#L37)

Type: `KamiSama.Extensions.WebModules.RazorComponentExtension`

Kind: `Method`

## Description

Runs the `AddRazorComponents<TRootComponent>` operation on `RazorComponentExtension`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRazorComponents<TRootComponent>(this ExtendedWebApplicationBuilder builder, Action<RazorComponentsEndpointConventionBuilder>? configure = null);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TRootComponent` | The `TRootComponent` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<RazorComponentsEndpointConventionBuilder>?` | `null` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

