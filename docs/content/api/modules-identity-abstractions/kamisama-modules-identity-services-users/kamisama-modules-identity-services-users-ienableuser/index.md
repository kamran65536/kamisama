# IEnableUser

<a id="ienableuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L45)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Enables a user according to implementation-defined lockout semantics. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IEnableUser
```

## Example

```csharp
await enableUser.EnableUserAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [EnableUserAsync](method-enableuserasync-51.md) | Enables the specified user. Use it with the surrounding package APIs when composing application code. |

