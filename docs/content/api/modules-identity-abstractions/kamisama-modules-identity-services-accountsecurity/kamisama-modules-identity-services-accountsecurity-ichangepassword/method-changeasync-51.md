# ChangeAsync

[Back to IChangePassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L51)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.IChangePassword`

Kind: `Method`

## Description

Changes the password described by the request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ChangePasswordRequest` | `-` | The target identity, current password, and replacement password. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the password change. |

## Example

```csharp
await changePassword.ChangeAsync(new ChangePasswordRequest(userId, username, email, currentPassword, newPassword), cancellationToken);
```

