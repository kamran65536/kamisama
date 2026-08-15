# Enable2faRequest

<a id="enable2farequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L29)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Record`

## Description

Supplies a user and verification code when enabling two-factor authentication. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record Enable2faRequest(Guid UserId, string VerificationCode);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L29)

Supplies a user and verification code when enabling two-factor authentication. Use it with the surrounding package APIs when composing application code.

```csharp
public record Enable2faRequest(Guid UserId, string VerificationCode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserId` | `Guid` | `-` | The target user identifier. |
| `VerificationCode` | `string` | `-` | The authenticator code that proves setup succeeded. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

