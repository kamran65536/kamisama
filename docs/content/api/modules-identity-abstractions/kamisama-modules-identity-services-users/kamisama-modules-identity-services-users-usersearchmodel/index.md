# UserSearchModel

<a id="usersearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L36)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Record`

## Description

Describes paging, identity text, role, and ordering criteria requested when users are listed. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Dtos.cs#L36)

Describes paging, identity text, role, and ordering criteria requested when users are listed. Use it with the surrounding package APIs when composing application code.

```csharp
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or zero when requesting all results. |
| `PageSize` | `int` | `-` | The maximum users in a page, or zero when requesting all results. |
| `UsernameOrEmail` | `string?` | `-` | Optional text used to filter by user name or email. |
| `RoleName` | `string?` | `-` | An optional role-name filter interpreted by the implementation. |
| `OrderBy` | `string?` | `-` | An optional implementation-defined ordering expression. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [All](field-all-40.md) | Gets a search model that requests all users without filtering or explicit ordering. Use it with the surrounding package APIs when composing application code. |

