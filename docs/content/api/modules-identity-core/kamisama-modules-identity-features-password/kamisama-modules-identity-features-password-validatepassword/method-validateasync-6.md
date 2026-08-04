# ValidateAsync

[Back to ValidatePassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Password/ValidatePassword.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Password/ValidatePassword.cs#L6)

Type: `KamiSama.Modules.Identity.Features.Password.ValidatePassword`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `ValidatePassword`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken);
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

