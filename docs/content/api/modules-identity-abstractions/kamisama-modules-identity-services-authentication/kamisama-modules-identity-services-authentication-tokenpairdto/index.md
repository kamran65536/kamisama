# TokenPairDto

<a id="tokenpairdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L25)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Record`

## Description

Carries access and refresh tokens for one session plus the access token's absolute UTC expiration. Clients can schedule renewal without decoding provider-specific token contents.

## Declaration

```csharp
public record TokenPairDto(string AccessToken, string RefreshToken, DateTimeOffset AccessTokenExpiresAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L25)

Groups an access token, its paired refresh token, and the access token&apos;s absolute expiration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TokenPairDto(string AccessToken, string RefreshToken, DateTimeOffset AccessTokenExpiresAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `AccessToken` | `string` | `-` | The signed access token. |
| `RefreshToken` | `string` | `-` | The provider token used to refresh the session. |
| `AccessTokenExpiresAt` | `DateTimeOffset` | `-` | The UTC instant after which the access token is no longer valid. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

