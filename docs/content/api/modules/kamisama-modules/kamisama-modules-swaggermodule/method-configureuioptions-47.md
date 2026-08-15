# ConfigureUiOptions

[Back to SwaggerModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/SwaggerModule.cs:47](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/SwaggerModule.cs#L47)

Type: `KamiSama.Modules.SwaggerModule`

Kind: `Method`

## Description

Invokes the constructor callback for Swagger UI options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureUiOptions(SwaggerUIOptions uiOptions);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `uiOptions` | `SwaggerUIOptions` | `-` | The UI options configured when middleware is added. |

## Example

No concise standalone example is available yet.

