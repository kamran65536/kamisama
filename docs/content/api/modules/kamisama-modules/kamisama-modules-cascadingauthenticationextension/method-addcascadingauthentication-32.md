# AddCascadingAuthentication

[Back to CascadingAuthenticationExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CascadingAuthenticationModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CascadingAuthenticationModule.cs#L32)

Type: `KamiSama.Modules.CascadingAuthenticationExtension`

Kind: `Method`

## Description

Queues cascading authentication-state service registration. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddCascadingAuthentication(this ExtendedWebApplicationBuilder builder);
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
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddCascadingAuthentication();
```

