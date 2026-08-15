# RoleDto

<a id="roledto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L20)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Record`

## Description

Transfers a role identifier and display name without exposing a provider entity. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record RoleDto(Guid Id, string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L20)

Transfers a role identifier and display name without exposing a provider entity. Use it with the surrounding package APIs when composing application code.

```csharp
public record RoleDto(Guid Id, string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The role identifier. |
| `Name` | `string` | `-` | The role name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

