# AddRazorPages

[Back to RazorPagesModuleExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RazorPagesModule.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RazorPagesModule.cs#L45)

Type: `KamiSama.Modules.RazorPagesModuleExtension`

Kind: `Method`

## Description

Queues Razor Pages service registration and endpoint mapping. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRazorPages(this ExtendedWebApplicationBuilder builder, Action<RazorPagesOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<RazorPagesOptions>?` | `-` | The optional Razor Pages options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddRazorPages(options => options.Conventions.AuthorizeFolder("/Admin"));
```

