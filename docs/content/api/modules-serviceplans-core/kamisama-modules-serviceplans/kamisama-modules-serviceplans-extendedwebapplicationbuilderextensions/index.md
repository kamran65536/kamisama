# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L70)

Namespace: `KamiSama.Modules.ServicePlans`

Kind: `Class`

## Description

Adds ServicePlans registration and post-build initialization to an extended builder. A matching provider callback is required in normal setup, and `BuildAsync` cannot provision the module schema from current provider packages.

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
| [AddServicePlansModule](method-addserviceplansmodule-80.md) | Queues ServicePlans service discovery, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; current provider packages contain no migrations, so `BuildAsync` cannot create the schema from this checkout. |

