# AddUserRequest

<a id="adduserrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L12)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Record`

## Description

Contains identity, credential, activation, and role values requested when a user is created. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L12)

Contains identity, credential, activation, and role values requested when a user is created. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserName` | `string` | `-` | The new user&apos;s sign-in name. |
| `Email` | `string` | `-` | The new user&apos;s email address. |
| `MobileNumber` | `string` | `-` | The new user&apos;s mobile phone number. |
| `Password` | `string` | `-` | The initial password. |
| `Activate` | `bool` | `-` | Whether the implementation should activate or confirm the account when supported. |
| `Roles` | `string[]` | `-` | The role names requested for the new user. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

