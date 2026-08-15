# ConfigureCorsPolicy

[Back to CorsModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CorsModule.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CorsModule.cs#L40)

Type: `KamiSama.Modules.CorsModule`

Kind: `Method`

## Description

Invokes the constructor callback for the inline CORS policy; derived modules can override the hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureCorsPolicy(CorsPolicyBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder` | `CorsPolicyBuilder` | `-` | The policy builder supplied by CORS middleware registration. |

## Example

No concise standalone example is available yet.

