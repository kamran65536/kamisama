# AddHttpsRedirection

[Back to HttpsRedirectionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/HttpsRedirectionModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/HttpsRedirectionModule.cs#L32)

Type: `KamiSama.Modules.HttpsRedirectionExtension`

Kind: `Method`

## Description

Queues HTTPS redirection middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddHttpsRedirection(this ExtendedWebApplicationBuilder builder);
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
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddHttpsRedirection();
```

