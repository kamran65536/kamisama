# AddUserRequest

<a id="adduserrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L5)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Record`

## Description

Provides the `AddUserRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserName` | `string` | `-` | The `UserName` value passed to this member. |
| `Email` | `string` | `-` | The `Email` value passed to this member. |
| `MobileNumber` | `string` | `-` | The `MobileNumber` value passed to this member. |
| `Password` | `string` | `-` | The `Password` value passed to this member. |
| `Activate` | `bool` | `-` | The `Activate` value passed to this member. |
| `Roles` | `string[]` | `-` | The `Roles` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

