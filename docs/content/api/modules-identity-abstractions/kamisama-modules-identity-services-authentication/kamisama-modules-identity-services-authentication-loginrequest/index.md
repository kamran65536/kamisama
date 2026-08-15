# LoginRequest

<a id="loginrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L9)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Record`

## Description

Carries one user name or email address, a password, and an optional authenticator code into `ILogin`. Using one login value avoids conflicting identity selectors; the implementation defines lookup and normalization behavior.

## Declaration

```csharp
public record LoginRequest(string Login, string Password, string? TwoFactorCode = null);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L9)

Supplies one user name or email address, a password, and an optional authenticator code for login. Use it with the surrounding package APIs when composing application code.

```csharp
public record LoginRequest(string Login, string Password, string? TwoFactorCode = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Login` | `string` | `-` | The user name or email address that identifies the account. |
| `Password` | `string` | `-` | The password to validate. |
| `TwoFactorCode` | `string?` | `null` | An optional authenticator code used when two-factor authentication is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

