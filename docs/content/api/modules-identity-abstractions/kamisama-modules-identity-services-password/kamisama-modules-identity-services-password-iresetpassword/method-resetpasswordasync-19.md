# ResetPasswordAsync

[Back to IResetPassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs#L19)

Type: `KamiSama.Modules.Identity.Services.Password.IResetPassword`

Kind: `Method`

## Description

Resets the password for the identity in the request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ResetPasswordRequest` | `-` | The identity lookup value and replacement password. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the reset operation. |

## Example

```csharp
// Do not expose Core's implementation directly: it generates its own reset token.
await resetPassword.ResetPasswordAsync(new ResetPasswordRequest("ada@example.com", replacementPassword), cancellationToken);
```

