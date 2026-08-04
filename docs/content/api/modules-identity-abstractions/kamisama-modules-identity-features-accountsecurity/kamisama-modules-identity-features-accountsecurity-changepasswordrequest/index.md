# ChangePasswordRequest

<a id="changepasswordrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L10)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Record`

## Description

Provides the `ChangePasswordRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L10)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

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
| `UserId` | `Guid` | `-` | The `UserId` value passed to this member. |
| `Username` | `string` | `-` | The `Username` value passed to this member. |
| `Email` | `string` | `-` | The `Email` value passed to this member. |
| `CurrentPassword` | `string` | `-` | The `CurrentPassword` value passed to this member. |
| `NewPassword` | `string` | `-` | The `NewPassword` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

