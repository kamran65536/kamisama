# LocalizedIdentityErrorDescriber

<a id="localizedidentityerrordescriber"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/LocalizedIdentityErrorDescriber.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/LocalizedIdentityErrorDescriber.cs#L5)

Namespace: `KamiSama.Modules.Identity.Wrappers`

Kind: `Class`

## Description

Provides the `LocalizedIdentityErrorDescriber` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class LocalizedIdentityErrorDescriber(IStringLocalizer<LocalizedIdentityErrorDescriber> localizer) : IdentityErrorDescriber
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/LocalizedIdentityErrorDescriber.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class LocalizedIdentityErrorDescriber(IStringLocalizer<LocalizedIdentityErrorDescriber> localizer) : IdentityErrorDescriber
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `localizer` | `IStringLocalizer<LocalizedIdentityErrorDescriber>` | `-` | The `localizer` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [PasswordRequiresDigit](method-passwordrequiresdigit-19.md) | Runs the `PasswordRequiresDigit` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |
| [PasswordRequiresLower](method-passwordrequireslower-16.md) | Runs the `PasswordRequiresLower` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |
| [PasswordRequiresNonAlphanumeric](method-passwordrequiresnonalphanumeric-10.md) | Runs the `PasswordRequiresNonAlphanumeric` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |
| [PasswordRequiresUniqueChars](method-passwordrequiresuniquechars-22.md) | Runs the `PasswordRequiresUniqueChars` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |
| [PasswordRequiresUpper](method-passwordrequiresupper-13.md) | Runs the `PasswordRequiresUpper` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |
| [PasswordTooShort](method-passwordtooshort-7.md) | Runs the `PasswordTooShort` operation on `LocalizedIdentityErrorDescriber`. Use it when your code needs this specific behavior from the package. |

