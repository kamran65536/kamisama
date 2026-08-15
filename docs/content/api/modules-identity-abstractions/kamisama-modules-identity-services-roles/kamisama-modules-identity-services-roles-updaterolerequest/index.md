# UpdateRoleRequest

<a id="updaterolerequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L26)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Record`

## Description

Contains the replacement name for an existing role. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdateRoleRequest(string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L26)

Contains the replacement name for an existing role. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateRoleRequest(string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement role name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

