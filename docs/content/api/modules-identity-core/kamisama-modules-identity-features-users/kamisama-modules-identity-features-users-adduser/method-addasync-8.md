# AddAsync

[Back to AddUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/AddUser.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/AddUser.cs#L8)

Type: `KamiSama.Modules.Identity.Features.Users.AddUser`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `AddUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<UserDto> AddAsync(AddUserRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddUserRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

