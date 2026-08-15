# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/LocationsModule.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/LocationsModule.cs#L48)

Namespace: `KamiSama.Modules.Locations`

Kind: `Class`

## Description

Adds the Locations web module, which discovers scoped features and repositories, configures a keyed provider-neutral context, and performs named database initialization after build. A matching provider callback is required in a normal host, and the module maps no controllers or endpoints.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddLocationsModule](method-addlocationsmodule-63.md) | Queues Locations service registration and post-build initialization. The callback must register a provider matching the database section's lowercased key; call `BuildAsync` before resolving feature services so registration, context resolution, and selected migration or seed stages complete. |

