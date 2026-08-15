# RefreshTokenRequest

<a id="refreshtokenrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L19)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Record`

## Description

Carries the access and refresh tokens that identify and prove authority over an existing session. Implementations validate the pair before issuing replacements.

## Declaration

```csharp
public record RefreshTokenRequest(string AccessToken, string RefreshToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L19)

Contains an expired or expiring access token and its paired refresh token. Use it with the surrounding package APIs when composing application code.

```csharp
public record RefreshTokenRequest(string AccessToken, string RefreshToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `AccessToken` | `string` | `-` | The signed access token whose principal identifies the session. |
| `RefreshToken` | `string` | `-` | The refresh token to validate for that session. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

