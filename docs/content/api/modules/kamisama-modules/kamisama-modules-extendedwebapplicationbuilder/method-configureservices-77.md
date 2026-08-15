# ConfigureServices

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:77](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L77)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Invokes a service-registration callback immediately rather than queueing it as a module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder ConfigureServices(Action<IServiceCollection> configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<IServiceCollection>` | `-` | The callback that receives the underlying service collection. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | This builder for fluent composition. |

## Example

No concise standalone example is available yet.

