# ValidateAuthenticationPassword

<a id="validateauthenticationpassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticationPassword.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticationPassword.cs#L8)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `ValidateAuthenticationPassword` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ValidateAuthenticationPassword(IUserManager userManager) : IValidateAuthenticationPassword
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticationPassword.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ValidateAuthenticationPassword(IUserManager userManager) : IValidateAuthenticationPassword
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-11.md) | Runs the `ValidateAsync` operation on `ValidateAuthenticationPassword`. Use it when your code needs this specific behavior from the package. |

