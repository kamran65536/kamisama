# ValidateAsync

[Back to IValidateAuthenticatorCode](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:82](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L82)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.IValidateAuthenticatorCode`

Kind: `Method`

## Description

Validates the code in the request and fails when it is invalid. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task ValidateAsync(ValidateAuthenticatorCodeRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ValidateAuthenticatorCodeRequest` | `-` | The user identifier and authenticator code. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents validation. |

## Example

```csharp
await validateAuthenticatorCode.ValidateAsync(new ValidateAuthenticatorCodeRequest(userId, authenticatorCode), cancellationToken);
```

