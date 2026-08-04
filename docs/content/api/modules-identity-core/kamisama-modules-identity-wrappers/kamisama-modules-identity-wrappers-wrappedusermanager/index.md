# WrappedUserManager

<a id="wrappedusermanager"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs#L3)

Namespace: `KamiSama.Modules.Identity.Wrappers`

Kind: `Class`

## Description

Provides the `WrappedUserManager` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class WrappedUserManager(UserManager<ApplicationUser> userManager) : IUserManager
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/WrappedUserManager.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class WrappedUserManager(UserManager<ApplicationUser> userManager) : IUserManager
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `UserManager<ApplicationUser>` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddToRolesAsync](method-addtorolesasync-28.md) | Runs the `AddToRolesAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [CheckPasswordAsync](method-checkpasswordasync-44.md) | Runs the `CheckPasswordAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ConfirmEmailAsync](method-confirmemailasync-26.md) | Runs the `ConfirmEmailAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ConvertId](method-convertid-7.md) | Runs the `ConvertId` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [CreateAsync](method-createasync-20.md) | Runs the `CreateAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [CreateAsync](method-createasync-22.md) | Runs the `CreateAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-18.md) | Runs the `DeleteAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByEmailAsync](method-findbyemailasync-8.md) | Runs the `FindByEmailAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-16.md) | Runs the `FindByIdAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByNameAsync](method-findbynameasync-14.md) | Runs the `FindByNameAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GenerateEmailConfirmationTokenAsync](method-generateemailconfirmationtokenasync-24.md) | Runs the `GenerateEmailConfirmationTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GeneratePasswordResetTokenAsync](method-generatepasswordresettokenasync-10.md) | Runs the `GeneratePasswordResetTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GenerateUserTokenAsync](method-generateusertokenasync-82.md) | Runs the `GenerateUserTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetAuthenticatorKeyAsync](method-getauthenticatorkeyasync-36.md) | Runs the `GetAuthenticatorKeyAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetRolesAsync](method-getrolesasync-12.md) | Runs the `GetRolesAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetTwoFactorEnabledAsync](method-gettwofactorenabledasync-34.md) | Runs the `GetTwoFactorEnabledAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [NormalizeEmail](method-normalizeemail-40.md) | Runs the `NormalizeEmail` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [NormalizeName](method-normalizename-42.md) | Runs the `NormalizeName` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetAccessFailedCountAsync](method-resetaccessfailedcountasync-80.md) | Runs the `ResetAccessFailedCountAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetAuthenticatorKeyAsync](method-resetauthenticatorkeyasync-38.md) | Runs the `ResetAuthenticatorKeyAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetPasswordAsync](method-resetpasswordasync-30.md) | Runs the `ResetPasswordAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetLockoutEnabledAsync](method-setlockoutenabledasync-74.md) | Runs the `SetLockoutEnabledAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetLockoutEndDateAsync](method-setlockoutenddateasync-76.md) | Runs the `SetLockoutEndDateAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetTwoFactoryEnabledAsync](method-settwofactoryenabledasync-32.md) | Runs the `SetTwoFactoryEnabledAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateAsync](method-updateasync-46.md) | Runs the `UpdateAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateNormalizedEmailAsync](method-updatenormalizedemailasync-50.md) | Runs the `UpdateNormalizedEmailAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateNormalizedUserNameAsync](method-updatenormalizedusernameasync-48.md) | Runs the `UpdateNormalizedUserNameAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateSecurityStampAsync](method-updatesecuritystampasync-78.md) | Runs the `UpdateSecurityStampAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [ValidatePasswordAsync](method-validatepasswordasync-52.md) | Runs the `ValidatePasswordAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [VerifyTwoFactorTokenAsync](method-verifytwofactortokenasync-85.md) | Runs the `VerifyTwoFactorTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |
| [VerifyUserTokenAsync](method-verifyusertokenasync-87.md) | Runs the `VerifyUserTokenAsync` operation on `WrappedUserManager`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [Options](property-options-6.md) | Exposes the `Options` value on `WrappedUserManager`. Read or set it as part of configuring or using the type. |

