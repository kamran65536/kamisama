# AuthenticateUserRequest

<a id="authenticateuserrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L8)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Record`

## Description

Provides the `AuthenticateUserRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record AuthenticateUserRequest(Guid? UserId, string? Username, string? Email, string Password, string? TwoFactorCode = null);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record AuthenticateUserRequest(Guid? UserId, string? Username, string? Email, string Password, string? TwoFactorCode = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserId` | `Guid?` | `-` | The `UserId` value passed to this member. |
| `Username` | `string?` | `-` | The `Username` value passed to this member. |
| `Email` | `string?` | `-` | The `Email` value passed to this member. |
| `Password` | `string` | `-` | The `Password` value passed to this member. |
| `TwoFactorCode` | `string?` | `null` | The `TwoFactorCode` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

