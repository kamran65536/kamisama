# ConfigureSwaggerGen

[Back to SwaggerModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/SwaggerModule.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/SwaggerModule.cs#L39)

Type: `KamiSama.Modules.SwaggerModule`

Kind: `Method`

## Description

Invokes the constructor callback for Swagger generation options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureSwaggerGen(SwaggerGenOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `SwaggerGenOptions` | `-` | The generation options configured before build. |

## Example

No concise standalone example is available yet.

