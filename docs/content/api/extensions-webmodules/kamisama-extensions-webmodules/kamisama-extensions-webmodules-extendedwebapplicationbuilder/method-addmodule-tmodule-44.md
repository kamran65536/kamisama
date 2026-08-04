# AddModule<TModule>

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L44)

Type: `KamiSama.Extensions.WebModules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Adds a new web module to be applied. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder AddModule<TModule>()
    where TModule : WebModule, new();
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TModule` | The `TModule` generic type argument. |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

