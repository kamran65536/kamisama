# AddModule<TModule>

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:53](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L53)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Creates a parameterless module, assigns this builder to it, and appends it to the ordered module queue. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder AddModule<TModule>()
    where TModule : WebModule, new();
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TModule` | The public parameterless module type to create. |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | This builder for fluent composition. |

## Example

No concise standalone example is available yet.

