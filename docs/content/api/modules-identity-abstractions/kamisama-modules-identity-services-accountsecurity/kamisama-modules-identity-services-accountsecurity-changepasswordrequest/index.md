# ChangePasswordRequest

<a id="changepasswordrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L22)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Record`

## Description

Supplies current credentials and a replacement password for a password-change workflow. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record ChangePasswordRequest(
	Guid UserId,
	string Username,
	string Email,
	string CurrentPassword,
	string NewPassword);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L22)

Supplies current credentials and a replacement password for a password-change workflow. Use it with the surrounding package APIs when composing application code.

```csharp
public record ChangePasswordRequest(
	Guid UserId,
	string Username,
	string Email,
	string CurrentPassword,
	string NewPassword);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserId` | `Guid` | `-` | The target user&apos;s identifier. |
| `Username` | `string` | `-` | The target user&apos;s name. |
| `Email` | `string` | `-` | The target user&apos;s email address. |
| `CurrentPassword` | `string` | `-` | The current password used to authenticate the request. |
| `NewPassword` | `string` | `-` | The replacement password. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

