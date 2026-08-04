# ApplicationUser

<a id="applicationuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L3)

Namespace: `KamiSama.Modules.Identity.Entities`

Kind: `Class`

## Description

Provides the `ApplicationUser` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class ApplicationUser : IdentityUser<Guid>
```

## Constructors

### ApplicationUser

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L5)

Initializes a new `ApplicationUser` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationUser();
```

## Parameters

This member does not declare parameters.

### ApplicationUser

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L6)

Initializes a new `ApplicationUser` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationUser(string userName) : base(userName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userName` | `string` | `-` | The `userName` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [Sessions](property-sessions-9.md) | Exposes the `Sessions` value on `ApplicationUser`. Read or set it as part of configuring or using the type. |

