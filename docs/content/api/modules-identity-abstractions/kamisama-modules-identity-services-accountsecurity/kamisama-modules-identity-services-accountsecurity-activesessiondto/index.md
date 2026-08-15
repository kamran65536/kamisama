# ActiveSessionDto

<a id="activesessiondto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L9)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Record`

## Description

Describes one active application session for account-security displays and revocation controls. Use it with the surrounding package APIs when composing application code.

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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L9)

Describes one active application session for account-security displays and revocation controls. Use it with the surrounding package APIs when composing application code.

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
| `Id` | `string` | `-` | The public session identifier. |
| `DeviceModel` | `string` | `-` | The device description captured when the session was created. |
| `LastConnection` | `DateTime` | `-` | The last recorded connection time. |
| `IpAddress` | `string` | `-` | The IP address captured for the session. |
| `IsCurrent` | `bool` | `-` | Whether this session is the caller&apos;s current session. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

