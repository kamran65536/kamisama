# CustomActionExtension

<a id="customactionextension"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/CustomActionModule.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L27)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Provides fluent synchronous and asynchronous custom post-build actions. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static class CustomActionExtension
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAction](method-addaction-36.md) | Wraps a synchronous application action in a queued `CustomActionModule`. Use it with the surrounding package APIs when composing application code. |
| [AddAction](method-addaction-45.md) | Queues an asynchronous application action in a `CustomActionModule`. Use it with the surrounding package APIs when composing application code. |

