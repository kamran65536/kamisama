# IResetPassword

<a id="iresetpassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs#L13)

Namespace: `KamiSama.Modules.Identity.Services.Password`

Kind: `Interface`

## Description

Resets a user&apos;s password according to implementation-defined identity lookup and token validation rules. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IResetPassword
```

## Example

```csharp
// Do not expose Core's implementation directly: it generates its own reset token.
await resetPassword.ResetPasswordAsync(new ResetPasswordRequest("ada@example.com", replacementPassword), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ResetPasswordAsync](method-resetpasswordasync-19.md) | Resets the password for the identity in the request. Use it with the surrounding package APIs when composing application code. |

