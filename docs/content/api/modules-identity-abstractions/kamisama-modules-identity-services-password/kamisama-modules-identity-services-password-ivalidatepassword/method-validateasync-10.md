# ValidateAsync

[Back to IValidatePassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Features.cs#L10)

Type: `KamiSama.Modules.Identity.Services.Password.IValidatePassword`

Kind: `Method`

## Description

Returns all password-policy errors detected for the supplied identity context and candidate password. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ValidatePasswordRequest` | `-` | The optional identity context and candidate password. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PasswordValidationError[]>` | The validation errors; an empty array indicates that the password passed validation. |

## Example

```csharp
PasswordValidationError[] errors = await validatePassword.ValidateAsync(new ValidatePasswordRequest("ada", "ada@example.com", null, candidatePassword), cancellationToken);
```

