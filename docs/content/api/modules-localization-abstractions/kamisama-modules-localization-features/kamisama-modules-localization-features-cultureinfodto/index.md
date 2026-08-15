# CultureInfoDto

<a id="cultureinfodto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs#L9)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Record`

## Description

Carries a display label, application-defined flag representation, and .NET culture name. It is shared by localization contracts and implementations.

## Declaration

```csharp
public record CultureInfoDto(string DisplayName, string RepresentedFlag, string Culture);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Dtos.cs#L9)

Carries display text, flag representation, and a .NET culture name between localization callers and implementations. Use it with the surrounding package APIs when composing application code.

```csharp
public record CultureInfoDto(string DisplayName, string RepresentedFlag, string Culture);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `DisplayName` | `string` | `-` | The human-readable culture label. |
| `RepresentedFlag` | `string` | `-` | The application-defined flag code or representation. |
| `Culture` | `string` | `-` | The culture name used to construct or compare `System.Globalization.CultureInfo` values. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

