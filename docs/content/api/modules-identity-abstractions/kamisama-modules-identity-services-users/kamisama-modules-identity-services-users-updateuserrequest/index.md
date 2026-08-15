# UpdateUserRequest

<a id="updateuserrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L18)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Record`

## Description

Contains replacement profile and role values requested for an existing user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdateUserRequest(string UserName, string Email, string MobileNumber, string[] Roles);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L18)

Contains replacement profile and role values requested for an existing user. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateUserRequest(string UserName, string Email, string MobileNumber, string[] Roles);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserName` | `string` | `-` | The replacement sign-in name. |
| `Email` | `string` | `-` | The replacement email address. |
| `MobileNumber` | `string` | `-` | The replacement mobile phone number. |
| `Roles` | `string[]` | `-` | The complete requested role-name set. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

