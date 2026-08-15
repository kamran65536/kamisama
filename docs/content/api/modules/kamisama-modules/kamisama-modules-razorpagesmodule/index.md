# RazorPagesModule

<a id="razorpagesmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/RazorPagesModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorPagesModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers configured Razor Pages services and maps page endpoints after build. Its endpoint mapping follows module insertion order.

## Declaration

```csharp
public class RazorPagesModule(Action<RazorPagesOptions>? configure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new RazorPagesModule(options => options.Conventions.AuthorizeFolder("/Admin")));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorPagesModule.cs#L9)

Registers Razor Pages with optional options customization and maps Razor Page endpoints after build. Use it with the surrounding package APIs when composing application code.

```csharp
public class RazorPagesModule(Action<RazorPagesOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RazorPagesOptions>?` | `-` | An optional callback for Razor Pages options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-21.md) | Maps Razor Page endpoints at this module&apos;s position in post-build order. Use it with the surrounding package APIs when composing application code. |
| [ConfigureRazorPages](method-configurerazorpages-31.md) | Invokes the constructor callback for Razor Pages options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Registers Razor Pages and invokes `ConfigureRazorPages` for options. Use it with the surrounding package APIs when composing application code. |

