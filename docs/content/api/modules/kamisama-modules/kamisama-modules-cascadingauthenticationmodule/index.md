# CascadingAuthenticationModule

<a id="cascadingauthenticationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/CascadingAuthenticationModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CascadingAuthenticationModule.cs#L7)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers Blazor cascading authentication-state services before build. It performs no post-build application configuration.

## Declaration

```csharp
public class CascadingAuthenticationModule : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new CascadingAuthenticationModule());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-19.md) | Performs no post-build work. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Registers cascading authentication-state services for Razor components. Use it with the surrounding package APIs when composing application code. |

