# LoginAsync

[Back to ILogin](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L10)

Type: `KamiSama.Modules.Identity.Services.Authentication.ILogin`

Kind: `Method`

## Description

Authenticates the supplied login and returns the user and new-session tokens. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `LoginRequest` | `-` | The login identifier, password, and optional two-factor code. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<LoginResponse>` | The authenticated user and tokens for the newly created session. |

## Example

```csharp
LoginResponse result = await login.LoginAsync(
    new LoginRequest("ada@example.com", password, authenticatorCode),
    cancellationToken);

DateTimeOffset renewBefore = result.Tokens.AccessTokenExpiresAt;
```

