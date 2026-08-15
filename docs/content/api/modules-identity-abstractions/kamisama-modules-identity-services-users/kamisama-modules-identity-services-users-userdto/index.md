# UserDto

<a id="userdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L25)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Record`

## Description

Transfers a user&apos;s identity, role names, and effective enabled state without exposing a provider entity. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UserDto(Guid Id, string Username, string Email, string[] Roles, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L25)

Transfers a user&apos;s identity, role names, and effective enabled state without exposing a provider entity. Use it with the surrounding package APIs when composing application code.

```csharp
public record UserDto(Guid Id, string Username, string Email, string[] Roles, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The user identifier. |
| `Username` | `string` | `-` | The user name. |
| `Email` | `string` | `-` | The email address. |
| `Roles` | `string[]` | `-` | The current role names. |
| `IsEnabled` | `bool` | `-` | Whether the implementation considers the user enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

