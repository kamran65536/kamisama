# ApplySearchModel

[Back to ApplicationUserRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs#L13)

Type: `KamiSama.Modules.Identity.Repositories.Implementations.ApplicationUserRepository`

Kind: `Method`

## Description

Runs the `ApplySearchModel` operation on `ApplicationUserRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override IQueryable<ApplicationUser> ApplySearchModel(IQueryable<ApplicationUser> query, UserSearchModel searchModel);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<ApplicationUser>` | `-` | The `query` value passed to this member. |
| `searchModel` | `UserSearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<ApplicationUser>` | Returns a `IQueryable<ApplicationUser>` value. |

## Example

No concise standalone example is available yet.

