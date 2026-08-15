# AntiForgeryModule

<a id="antiforgerymodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/AntiForgeryModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/AntiForgeryModule.cs#L8)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Adds antiforgery middleware after build but does not register the required antiforgery services. Register them separately before adding this module.

## Declaration

```csharp
public class AntiForgeryModule : WebModule
```

## Example

```csharp
webBuilder.Services.AddAntiforgery();
var builder = webBuilder.Extend().AddModule(new AntiForgeryModule());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-19.md) | Adds ASP.NET Core antiforgery middleware by calling `AntiforgeryApplicationBuilderExtensions.UseAntiforgery`. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-12.md) | Performs no service registration; callers must register antiforgery services separately before build. Use it with the surrounding package APIs when composing application code. |

