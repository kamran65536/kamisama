# AddAntiForgery

[Back to AntiForgeryExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/AntiForgeryModule.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/AntiForgeryModule.cs#L34)

Type: `KamiSama.Modules.AntiForgeryExtension`

Kind: `Method`

## Description

Queues antiforgery middleware without adding the required antiforgery services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddAntiForgery(this ExtendedWebApplicationBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
webBuilder.Services.AddAntiforgery();
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddAntiForgery();
```

