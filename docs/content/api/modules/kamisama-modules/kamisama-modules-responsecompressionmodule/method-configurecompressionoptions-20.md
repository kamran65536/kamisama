# ConfigureCompressionOptions

[Back to ResponseCompressionModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ResponseCompressionModule.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCompressionModule.cs#L20)

Type: `KamiSama.Modules.ResponseCompressionModule`

Kind: `Method`

## Description

Invokes the constructor callback for response-compression options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureCompressionOptions(ResponseCompressionOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `ResponseCompressionOptions` | `-` | The response-compression options configured before build. |

## Example

No concise standalone example is available yet.

