# ConfigureResponseCachingOptions

[Back to ResponseCachingModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ResponseCachingModule.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L21)

Type: `KamiSama.Modules.ResponseCachingModule`

Kind: `Method`

## Description

Invokes the constructor callback for response-caching options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureResponseCachingOptions(ResponseCachingOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `ResponseCachingOptions` | `-` | The response-caching options configured before build. |

## Example

No concise standalone example is available yet.

