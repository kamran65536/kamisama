# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:125](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L125)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

Adds the Identity Core web module to an extended builder. Its provider callback must register one installed Identity database provider before startup context resolution.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddKamiSamaIdentityModule](method-addkamisamaidentitymodule-135.md) | Adds Identity registration and startup initialization to an extended application builder. Use it with the surrounding package APIs when composing application code. |

