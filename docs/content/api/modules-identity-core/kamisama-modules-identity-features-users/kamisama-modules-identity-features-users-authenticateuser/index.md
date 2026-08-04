# AuthenticateUser

<a id="authenticateuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/AuthenticateUser.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AuthenticateUser.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `AuthenticateUser` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class AuthenticateUser(
	IResolveAuthenticationUser resolveAuthenticationUser,
	IValidateAuthenticationPassword validateAuthenticationPassword,
	IValidateAuthenticatorCodeIfEnabled validateAuthenticatorCodeIfEnabled,
	IUserManager userManager) : IAuthenticateUser
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AuthenticateUser.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class AuthenticateUser(
	IResolveAuthenticationUser resolveAuthenticationUser,
	IValidateAuthenticationPassword validateAuthenticationPassword,
	IValidateAuthenticatorCodeIfEnabled validateAuthenticatorCodeIfEnabled,
	IUserManager userManager) : IAuthenticateUser
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `resolveAuthenticationUser` | `IResolveAuthenticationUser` | `-` | The `resolveAuthenticationUser` value passed to this member. |
| `validateAuthenticationPassword` | `IValidateAuthenticationPassword` | `-` | The `validateAuthenticationPassword` value passed to this member. |
| `validateAuthenticatorCodeIfEnabled` | `IValidateAuthenticatorCodeIfEnabled` | `-` | The `validateAuthenticatorCodeIfEnabled` value passed to this member. |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AuthenticateAsync](method-authenticateasync-10.md) | Runs the `AuthenticateAsync` operation on `AuthenticateUser`. Use it when your code needs this specific behavior from the package. |

