# AddUser

<a id="adduser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/AddUser.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AddUser.cs#L5)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `AddUser` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class AddUser(IUserManager userManager) : IAddUser
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AddUser.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class AddUser(IUserManager userManager) : IAddUser
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-8.md) | Runs the `AddAsync` operation on `AddUser`. Use it when your code needs this specific behavior from the package. |

