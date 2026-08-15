# StaticFilesModule

<a id="staticfilesmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/StaticFilesModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/StaticFilesModule.cs#L7)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Maps ASP.NET Core static assets after build through `MapStaticAssets`. It does not add conventional static-file middleware.

## Declaration

```csharp
public class StaticFilesModule : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new StaticFilesModule());
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-18.md) | Maps static assets by calling `MapStaticAssets` at this module&apos;s position in post-build order. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Performs no service registration. Use it with the surrounding package APIs when composing application code. |

