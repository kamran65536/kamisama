# ConfigureForwaredHeadersOptions

[Back to ForwardedHeadersModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ForwardedHeadersModule.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ForwardedHeadersModule.cs#L33)

Type: `KamiSama.Modules.ForwardedHeadersModule`

Kind: `Method`

## Description

Invokes the constructor callback for forwarded-header options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureForwaredHeadersOptions(ForwardedHeadersOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `ForwardedHeadersOptions` | `-` | The newly created options passed to middleware registration. |

## Example

No concise standalone example is available yet.

