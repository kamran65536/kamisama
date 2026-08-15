# RoleSearchModel

<a id="rolesearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L10)

Namespace: `KamiSama.Modules.Identity.Services.Roles`

Kind: `Record`

## Description

Describes paging, name filtering, and ordering requested when roles are listed. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record RoleSearchModel(int Page, int PageSize, string? Name, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Roles/Dtos.cs#L10)

Describes paging, name filtering, and ordering requested when roles are listed. Use it with the surrounding package APIs when composing application code.

```csharp
public record RoleSearchModel(int Page, int PageSize, string? Name, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or zero when requesting all results. |
| `PageSize` | `int` | `-` | The maximum number of roles in a page, or zero when requesting all results. |
| `Name` | `string?` | `-` | An optional role-name filter interpreted by the implementation. |
| `OrderBy` | `string?` | `-` | An optional implementation-defined ordering expression. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [All](field-all-14.md) | Gets a search model that requests all roles without filtering or explicit ordering. Use it with the surrounding package APIs when composing application code. |

