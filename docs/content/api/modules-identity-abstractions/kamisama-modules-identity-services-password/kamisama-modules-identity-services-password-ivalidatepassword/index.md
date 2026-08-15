# IValidatePassword

<a id="ivalidatepassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs#L4)

Namespace: `KamiSama.Modules.Identity.Services.Password`

Kind: `Interface`

## Description

Validates a candidate password against an implementation&apos;s configured password policy. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IValidatePassword
```

## Example

```csharp
PasswordValidationError[] errors = await validatePassword.ValidateAsync(new ValidatePasswordRequest("ada", "ada@example.com", null, candidatePassword), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-10.md) | Returns all password-policy errors detected for the supplied identity context and candidate password. Use it with the surrounding package APIs when composing application code. |

