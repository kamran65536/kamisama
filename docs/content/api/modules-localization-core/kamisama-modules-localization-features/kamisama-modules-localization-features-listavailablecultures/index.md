# ListAvailableCultures

<a id="listavailablecultures"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L5)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Class`

## Description

Provides the `ListAvailableCultures` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/ListAvailableCultures.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<LocalizationOptions>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-8.md) | Runs the `ListAsync` operation on `ListAvailableCultures`. Use it when your code needs this specific behavior from the package. |

