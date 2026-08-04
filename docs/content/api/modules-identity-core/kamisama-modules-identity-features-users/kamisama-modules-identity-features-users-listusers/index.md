# ListUsers

<a id="listusers"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs#L6)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `ListUsers` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ListUsers(IApplicationUserRepository repository, IUserManager userManager) :
	GenericListFeature<ApplicationUser, UserDto, UserSearchModel, IApplicationUserRepository>(repository),
	IListUsers
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ListUsers(IApplicationUserRepository repository, IUserManager userManager) :
	GenericListFeature<ApplicationUser, UserDto, UserSearchModel, IApplicationUserRepository>(repository),
	IListUsers
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `IApplicationUserRepository` | `-` | The `repository` value passed to this member. |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-32.md) | Runs the `ConvertToDto` operation on `ListUsers`. Use it when your code needs this specific behavior from the package. |
| [ConvertToPagedResultAsync](method-converttopagedresultasync-17.md) | This method is overridden as concurrent access to `IUserManager.GetRolesAsync(ApplicationUser)` is not possible. Use it with the surrounding package APIs when composing application code. |

