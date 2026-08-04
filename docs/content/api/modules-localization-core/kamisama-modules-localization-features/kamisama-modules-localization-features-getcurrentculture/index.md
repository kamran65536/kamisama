# GetCurrentCulture

<a id="getcurrentculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L7)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Class`

## Description

Provides the `GetCurrentCulture` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/GetCurrentCulture.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<LocalizationOptions>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentCultureAsync](method-getcurrentcultureasync-10.md) | Runs the `GetCurrentCultureAsync` operation on `GetCurrentCulture`. Use it when your code needs this specific behavior from the package. |

