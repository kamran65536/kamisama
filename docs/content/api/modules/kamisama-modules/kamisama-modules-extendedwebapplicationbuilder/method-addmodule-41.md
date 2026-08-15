# AddModule

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L41)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Assigns this builder to the module and appends the same instance to the ordered module queue. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder AddModule(WebModule module);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `module` | `WebModule` | `-` | The module instance to queue. No duplicate detection is performed. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | This builder for fluent composition. |

## Example

No concise standalone example is available yet.

