# ApplicationRole

<a id="applicationrole"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L3)

Namespace: `KamiSama.Modules.Identity.Entities`

Kind: `Class`

## Description

Provides the `ApplicationRole` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class ApplicationRole : IdentityRole<Guid>
```

## Constructors

### ApplicationRole

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L5)

Initializes a new `ApplicationRole` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationRole();
```

## Parameters

This member does not declare parameters.

### ApplicationRole

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationRole.cs#L6)

Initializes a new `ApplicationRole` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationRole(string roleName) : base(roleName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `roleName` | `string` | `-` | The `roleName` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

