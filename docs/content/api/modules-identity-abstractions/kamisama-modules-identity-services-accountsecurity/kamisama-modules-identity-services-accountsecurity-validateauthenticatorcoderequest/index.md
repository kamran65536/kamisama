# ValidateAuthenticatorCodeRequest

<a id="validateauthenticatorcoderequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L32)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Record`

## Description

Supplies a user identifier and time-based authenticator code for validation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Dtos.cs#L32)

Supplies a user identifier and time-based authenticator code for validation. Use it with the surrounding package APIs when composing application code.

```csharp
public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserId` | `Guid` | `-` | The target user&apos;s identifier. |
| `AuthenticatorCode` | `string` | `-` | The authenticator code to validate. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

