# HttpsRedirectionModule

<a id="httpsredirectionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/HttpsRedirectionModule.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/HttpsRedirectionModule.cs#L6)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Adds HTTPS redirection middleware after build with framework-configured options. It performs no service registration.

## Declaration

```csharp
public class HttpsRedirectionModule : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new HttpsRedirectionModule());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Adds HTTPS redirection middleware at this module&apos;s position in the ordered pipeline. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-10.md) | Performs no service registration. Use it with the surrounding package APIs when composing application code. |

