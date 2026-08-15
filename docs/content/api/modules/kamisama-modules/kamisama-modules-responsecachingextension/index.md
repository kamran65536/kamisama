# ResponseCachingExtension

<a id="responsecachingextension"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ResponseCachingModule.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L34)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Provides fluent registration of the currently incomplete `ResponseCachingModule`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static class ResponseCachingExtension
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddResponseCaching](method-addresponsecaching-42.md) | Queues response-caching service registration; the subsequent application build fails when the module&apos;s post-build method throws. Use it with the surrounding package APIs when composing application code. |

