# ApplicationUser

<a id="applicationuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L7)

Namespace: `KamiSama.Modules.Identity.Entities`

Kind: `Class`

## Description

ASP.NET Core Identity user with a `Guid` key and application-session navigation. Inherited Identity state stores credentials, confirmation, and lockout data.

## Declaration

```csharp
public class ApplicationUser : IdentityUser<Guid>
```

## Example

```csharp
var user = new ApplicationUser("ada")
{
    Id = Guid.NewGuid(),
    Email = "ada@example.com"
};
```

## Constructors

### ApplicationUser

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L10)

Initializes an empty user for Identity and Entity Framework Core materialization. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationUser();
```

## Parameters

This member does not declare parameters.

### ApplicationUser

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L13)

Initializes a user with the supplied user name. Use it with the surrounding package APIs when composing application code.

```csharp
public ApplicationUser(string userName) : base(userName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userName` | `string` | `-` | The initial user name. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [Sessions](property-sessions-17.md) | Gets or sets the sessions associated with this user. Use it with the surrounding package APIs when composing application code. |

