# IUserManager

<a id="iusermanager"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:2](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L2)

Namespace: `KamiSama.Modules.Identity.Wrappers`

Kind: `Interface`

## Description

Defines the contract for `IUserManager` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
internal interface IUserManager
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddToRolesAsync](method-addtorolesasync-16.md) | Runs the `AddToRolesAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [CheckPasswordAsync](method-checkpasswordasync-24.md) | Runs the `CheckPasswordAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ConfirmEmailAsync](method-confirmemailasync-15.md) | Runs the `ConfirmEmailAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ConvertId](method-convertid-5.md) | Runs the `ConvertId` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [CreateAsync](method-createasync-11.md) | Runs the `CreateAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [CreateAsync](method-createasync-12.md) | Runs the `CreateAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-10.md) | Runs the `DeleteAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByEmailAsync](method-findbyemailasync-6.md) | Runs the `FindByEmailAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-7.md) | Runs the `FindByIdAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [FindByNameAsync](method-findbynameasync-8.md) | Runs the `FindByNameAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GenerateEmailConfirmationTokenAsync](method-generateemailconfirmationtokenasync-14.md) | Runs the `GenerateEmailConfirmationTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GeneratePasswordResetTokenAsync](method-generatepasswordresettokenasync-13.md) | Runs the `GeneratePasswordResetTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GenerateUserTokenAsync](method-generateusertokenasync-30.md) | Runs the `GenerateUserTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetAuthenticatorKeyAsync](method-getauthenticatorkeyasync-20.md) | Runs the `GetAuthenticatorKeyAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetRolesAsync](method-getrolesasync-9.md) | Runs the `GetRolesAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [GetTwoFactorEnabledAsync](method-gettwofactorenabledasync-19.md) | Runs the `GetTwoFactorEnabledAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [NormalizeEmail](method-normalizeemail-22.md) | Runs the `NormalizeEmail` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [NormalizeName](method-normalizename-23.md) | Runs the `NormalizeName` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetAccessFailedCountAsync](method-resetaccessfailedcountasync-29.md) | Runs the `ResetAccessFailedCountAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetAuthenticatorKeyAsync](method-resetauthenticatorkeyasync-21.md) | Runs the `ResetAuthenticatorKeyAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ResetPasswordAsync](method-resetpasswordasync-17.md) | Runs the `ResetPasswordAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetLockoutEnabledAsync](method-setlockoutenabledasync-26.md) | Runs the `SetLockoutEnabledAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetLockoutEndDateAsync](method-setlockoutenddateasync-27.md) | Runs the `SetLockoutEndDateAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [SetTwoFactoryEnabledAsync](method-settwofactoryenabledasync-18.md) | Runs the `SetTwoFactoryEnabledAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateAsync](method-updateasync-31.md) | Runs the `UpdateAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateNormalizedEmailAsync](method-updatenormalizedemailasync-33.md) | Runs the `UpdateNormalizedEmailAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateNormalizedUserNameAsync](method-updatenormalizedusernameasync-32.md) | Runs the `UpdateNormalizedUserNameAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [UpdateSecurityStampAsync](method-updatesecuritystampasync-28.md) | Runs the `UpdateSecurityStampAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [ValidatePasswordAsync](method-validatepasswordasync-25.md) | Runs the `ValidatePasswordAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [VerifyTwoFactorTokenAsync](method-verifytwofactortokenasync-35.md) | Runs the `VerifyTwoFactorTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |
| [VerifyUserTokenAsync](method-verifyusertokenasync-34.md) | Runs the `VerifyUserTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [Options](property-options-4.md) | Exposes the `Options` value on `IUserManager`. Read or set it as part of configuring or using the type. |

