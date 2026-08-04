# SendConfirmationLinkAsync

[Back to EmailSender](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Email/EmailSender.cs#L7)

Type: `KamiSama.Modules.Identity.Features.Email.EmailSender`

Kind: `Method`

## Description

Runs the `SendConfirmationLinkAsync` operation on `EmailSender`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `email` | `string` | `-` | The `email` value passed to this member. |
| `confirmationLink` | `string` | `-` | The `confirmationLink` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

