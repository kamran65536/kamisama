# AddResponseCaching

[Back to ResponseCachingExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ResponseCachingModule.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L42)

Type: `KamiSama.Modules.ResponseCachingExtension`

Kind: `Method`

## Description

Queues response-caching service registration; the subsequent application build fails when the module&apos;s post-build method throws. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddResponseCaching(this ExtendedWebApplicationBuilder builder, Action<ResponseCachingOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<ResponseCachingOptions>?` | `-` | An optional response-caching options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
// Build or BuildAsync will throw while this module is present.
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddResponseCaching(configure: null);
```

