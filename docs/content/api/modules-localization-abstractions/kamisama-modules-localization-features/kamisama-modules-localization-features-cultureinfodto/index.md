# CultureInfoDto

<a id="cultureinfodto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs#L3)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Record`

## Description

Provides the `CultureInfoDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record CultureInfoDto(string DisplayName, string RepresentedFlag, string Culture);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record CultureInfoDto(string DisplayName, string RepresentedFlag, string Culture);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `DisplayName` | `string` | `-` | The `DisplayName` value passed to this member. |
| `RepresentedFlag` | `string` | `-` | The `RepresentedFlag` value passed to this member. |
| `Culture` | `string` | `-` | The `Culture` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

