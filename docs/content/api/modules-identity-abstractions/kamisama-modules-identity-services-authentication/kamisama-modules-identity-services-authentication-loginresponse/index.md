# LoginResponse

<a id="loginresponse"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L14)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Record`

## Description

Returns the provider-neutral authenticated user together with the token pair issued for a newly created session. Callers can establish identity state without invoking a separate public token-issuance service.

## Declaration

```csharp
public record LoginResponse(UserDto User, TokenPairDto Tokens);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Dtos.cs#L14)

Returns the authenticated user together with the tokens issued for the new session. Use it with the surrounding package APIs when composing application code.

```csharp
public record LoginResponse(UserDto User, TokenPairDto Tokens);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `User` | `UserDto` | `-` | The provider-neutral authenticated user. |
| `Tokens` | `TokenPairDto` | `-` | The access and refresh tokens issued for the session. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

