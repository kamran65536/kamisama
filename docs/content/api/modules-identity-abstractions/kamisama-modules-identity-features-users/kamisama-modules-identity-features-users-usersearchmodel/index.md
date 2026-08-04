# UserSearchModel

<a id="usersearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L13)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Record`

## Description

Provides the `UserSearchModel` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L13)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The `Page` value passed to this member. |
| `PageSize` | `int` | `-` | The `PageSize` value passed to this member. |
| `UsernameOrEmail` | `string?` | `-` | The `UsernameOrEmail` value passed to this member. |
| `RoleName` | `string?` | `-` | The `RoleName` value passed to this member. |
| `OrderBy` | `string?` | `-` | The `OrderBy` value passed to this member. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [All](field-all-16.md) | Stores the `All` value for `UserSearchModel`. Use it where the package exposes this field as part of its API. |

