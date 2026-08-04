# ValidateAsync

[Back to IValidatePassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs#L5)

Type: `KamiSama.Modules.Identity.Features.Password.IValidatePassword`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `IValidatePassword`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ValidatePasswordRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PasswordValidationError[]>` | Returns a `Task<PasswordValidationError[]>` value. |

## Example

No concise standalone example is available yet.

