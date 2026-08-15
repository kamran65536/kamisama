# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L51)

Namespace: `KamiSama.Modules.Localization`

Kind: `Class`

## Description

Adds request localization and the localization core module in the required order. Provider insertion produces Accept-Language, query-string, then cookie precedence.

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
| [AddLocalizationModule](method-addlocalizationmodule-59.md) | Reads localization settings immediately, configures supported cultures, and queues request localization before `LocalizationModule`. Provider insertion yields effective precedence of Accept-Language header, query string, then cookie. |

