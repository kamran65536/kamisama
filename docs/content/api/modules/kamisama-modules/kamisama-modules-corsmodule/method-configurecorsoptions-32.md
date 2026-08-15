# ConfigureCorsOptions

[Back to CorsModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CorsModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CorsModule.cs#L32)

Type: `KamiSama.Modules.CorsModule`

Kind: `Method`

## Description

Invokes the constructor callback for service-level CORS options; derived modules can override the hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureCorsOptions(CorsOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `CorsOptions` | `-` | The CORS options being registered. |

## Example

No concise standalone example is available yet.

