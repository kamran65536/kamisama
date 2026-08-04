# ResetPasswordAsync

[Back to IResetPassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs#L9)

Type: `KamiSama.Modules.Identity.Features.Password.IResetPassword`

Kind: `Method`

## Description

Runs the `ResetPasswordAsync` operation on `IResetPassword`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ResetPasswordRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

