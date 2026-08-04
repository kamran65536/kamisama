# ActiveSessionDto

<a id="activesessiondto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Record`

## Description

Provides the `ActiveSessionDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record ActiveSessionDto(
	string Id,
	string DeviceModel,
	DateTime LastConnection,
	string IpAddress,
	bool IsCurrent);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record ActiveSessionDto(
	string Id,
	string DeviceModel,
	DateTime LastConnection,
	string IpAddress,
	bool IsCurrent);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `string` | `-` | The `Id` value passed to this member. |
| `DeviceModel` | `string` | `-` | The `DeviceModel` value passed to this member. |
| `LastConnection` | `DateTime` | `-` | The `LastConnection` value passed to this member. |
| `IpAddress` | `string` | `-` | The `IpAddress` value passed to this member. |
| `IsCurrent` | `bool` | `-` | The `IsCurrent` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

