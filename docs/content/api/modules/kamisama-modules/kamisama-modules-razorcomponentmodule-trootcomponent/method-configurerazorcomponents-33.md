# ConfigureRazorComponents

[Back to RazorComponentModule<TRootComponent>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RazorComponentModule.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorComponentModule.cs#L33)

Type: `KamiSama.Modules.RazorComponentModule<TRootComponent>`

Kind: `Method`

## Description

Invokes the constructor callback for the mapped Razor component endpoint; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureRazorComponents(RazorComponentsEndpointConventionBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder` | `RazorComponentsEndpointConventionBuilder` | `-` | The endpoint convention builder returned when the root component is mapped. |

## Example

No concise standalone example is available yet.

