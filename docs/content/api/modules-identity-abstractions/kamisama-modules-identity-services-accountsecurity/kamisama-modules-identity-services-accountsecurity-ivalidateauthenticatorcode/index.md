# IValidateAuthenticatorCode

<a id="ivalidateauthenticatorcode"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:76](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L76)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Validates a time-based authenticator code for a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IValidateAuthenticatorCode
```

## Example

```csharp
await validateAuthenticatorCode.ValidateAsync(new ValidateAuthenticatorCodeRequest(userId, authenticatorCode), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-82.md) | Validates the code in the request and fails when it is invalid. Use it with the surrounding package APIs when composing application code. |

