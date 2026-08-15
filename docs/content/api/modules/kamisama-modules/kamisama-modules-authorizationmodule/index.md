# AuthorizationModule

<a id="authorizationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/AuthorizationModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/AuthorizationModule.cs#L7)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers authorization services before build and adds authorization middleware afterward. Its position in module order determines middleware order.

## Declaration

```csharp
public class AuthorizationModule : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new AuthorizationModule());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Adds authorization middleware at this module&apos;s position in the ordered post-build pipeline. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Registers ASP.NET Core authorization services with default options. Use it with the surrounding package APIs when composing application code. |

