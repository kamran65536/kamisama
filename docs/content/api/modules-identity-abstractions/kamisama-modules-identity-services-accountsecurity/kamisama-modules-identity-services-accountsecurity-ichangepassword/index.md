# IChangePassword

<a id="ichangepassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L45)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Authenticates current credentials and changes a user&apos;s password. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IChangePassword
```

## Example

```csharp
await changePassword.ChangeAsync(new ChangePasswordRequest(userId, username, email, currentPassword, newPassword), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ChangeAsync](method-changeasync-51.md) | Changes the password described by the request. Use it with the surrounding package APIs when composing application code. |

