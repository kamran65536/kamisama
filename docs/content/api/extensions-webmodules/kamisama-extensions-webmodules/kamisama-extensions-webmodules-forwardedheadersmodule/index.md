# ForwardedHeadersModule

<a id="forwardedheadersmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ForwardedHeadersModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ForwardedHeadersModule.cs#L7)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `ForwardedHeadersModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ForwardedHeadersModule.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ForwardedHeadersOptions>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-14.md) | Runs the `ApplyConfigurationToAsync` operation on `ForwardedHeadersModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureForwaredHeadersOptions](method-configureforwaredheadersoptions-27.md) | Configures the forwarded headers options for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `ForwardedHeadersModule`. Use it when your code needs this specific behavior from the package. |

