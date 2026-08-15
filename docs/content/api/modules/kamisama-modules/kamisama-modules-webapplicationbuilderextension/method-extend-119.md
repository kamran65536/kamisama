# Extend

[Back to WebApplicationBuilderExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:119](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L119)

Type: `KamiSama.Modules.WebApplicationBuilderExtension`

Kind: `Method`

## Description

Creates an extended wrapper around the supplied builder without building it or changing its services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder Extend(this WebApplicationBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `WebApplicationBuilder` | `-` | The standard application builder to wrap. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | A new extended builder backed by &lt;paramref name=&quot;builder&quot;/&gt;. |

## Example

```csharp
using KamiSama.Modules;

ExtendedWebApplicationBuilder builder = WebApplication.CreateBuilder(args).Extend();
```

