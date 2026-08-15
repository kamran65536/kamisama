# ConfigureMvcBuilder

[Back to ControllersModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ControllersModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L32)

Type: `KamiSama.Modules.ControllersModule`

Kind: `Method`

## Description

Invokes the constructor callback for the MVC builder; derived modules can override this hook to add controller conventions or features. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureMvcBuilder(IMvcBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder` | `IMvcBuilder` | `-` | The MVC builder returned by service registration. |

## Example

No concise standalone example is available yet.

