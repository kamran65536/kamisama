# ChangePassword

<a id="changepassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ChangePassword.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ChangePassword.cs#L6)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ChangePassword` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ChangePassword(
	IAuthenticateUser authenticateUser,
	IResetPassword resetPassword) : IChangePassword
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ChangePassword.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ChangePassword(
	IAuthenticateUser authenticateUser,
	IResetPassword resetPassword) : IChangePassword
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `authenticateUser` | `IAuthenticateUser` | `-` | The `authenticateUser` value passed to this member. |
| `resetPassword` | `IResetPassword` | `-` | The `resetPassword` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ChangeAsync](method-changeasync-11.md) | Runs the `ChangeAsync` operation on `ChangePassword`. Use it when your code needs this specific behavior from the package. |

