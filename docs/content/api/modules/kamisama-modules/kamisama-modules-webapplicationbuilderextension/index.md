# WebApplicationBuilderExtension

<a id="webapplicationbuilderextension"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:112](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L112)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Wraps a standard `WebApplicationBuilder` in an `ExtendedWebApplicationBuilder`. Wrapping alone does not register services or build the application.

## Declaration

```csharp
public static class WebApplicationBuilderExtension
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Extend](method-extend-119.md) | Creates an extended wrapper around the supplied builder without building it or changing its services. Use it with the surrounding package APIs when composing application code. |

