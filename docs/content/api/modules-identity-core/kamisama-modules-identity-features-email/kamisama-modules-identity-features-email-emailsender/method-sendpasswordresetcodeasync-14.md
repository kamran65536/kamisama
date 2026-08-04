# SendPasswordResetCodeAsync

[Back to EmailSender](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs#L14)

Type: `KamiSama.Modules.Identity.Features.Email.EmailSender`

Kind: `Method`

## Description

Runs the `SendPasswordResetCodeAsync` operation on `EmailSender`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `email` | `string` | `-` | The `email` value passed to this member. |
| `resetCode` | `string` | `-` | The `resetCode` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

