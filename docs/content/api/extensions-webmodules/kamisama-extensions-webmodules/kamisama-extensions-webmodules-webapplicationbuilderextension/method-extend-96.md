# Extend

[Back to WebApplicationBuilderExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:96](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L96)

Type: `KamiSama.Extensions.WebModules.WebApplicationBuilderExtension`

Kind: `Method`

## Description

Extends Web Application builder functionalities. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder Extend(this WebApplicationBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `WebApplicationBuilder` | `-` | The `builder` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

```csharp
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args).Extend();
```

