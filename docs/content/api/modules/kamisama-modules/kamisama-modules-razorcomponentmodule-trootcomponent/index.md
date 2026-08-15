# RazorComponentModule<TRootComponent>

<a id="razorcomponentmodule-trootcomponent"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/RazorComponentModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorComponentModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers Razor component services and maps the selected root component after build. The endpoint callback can add conventions to the mapped component.

## Declaration

```csharp
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new RazorComponentModule<App>(endpoints => endpoints.AddInteractiveServerRenderMode()));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorComponentModule.cs#L9)

Registers Razor components and maps one root component with optional endpoint customization. Use it with the surrounding package APIs when composing application code.

```csharp
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RazorComponentsEndpointConventionBuilder>?` | `-` | An optional callback for the mapped component endpoint builder. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-21.md) | Maps &lt;typeparamref name=&quot;TRootComponent&quot;/&gt; and invokes `ConfigureRazorComponents` on the endpoint builder. Use it with the surrounding package APIs when composing application code. |
| [ConfigureRazorComponents](method-configurerazorcomponents-33.md) | Invokes the constructor callback for the mapped Razor component endpoint; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Registers Razor component services with default options. Use it with the surrounding package APIs when composing application code. |

