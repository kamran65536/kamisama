# AddCors

[Back to CorsExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/CorsModule.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CorsModule.cs#L45)

Type: `KamiSama.Extensions.WebModules.CorsExtension`

Kind: `Method`

## Description

Runs the `AddCors` operation on `CorsExtension`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddCors(this ExtendedWebApplicationBuilder builder, Action<CorsOptions>? configOptions = null, Action<CorsPolicyBuilder>? configurePolicy = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configOptions` | `Action<CorsOptions>?` | `null` | The `configOptions` value passed to this member. |
| `configurePolicy` | `Action<CorsPolicyBuilder>?` | `null` | The `configurePolicy` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

