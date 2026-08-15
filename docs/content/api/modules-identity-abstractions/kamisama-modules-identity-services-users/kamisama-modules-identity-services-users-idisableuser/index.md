# IDisableUser

<a id="idisableuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L36)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Disables a user&apos;s ability to authenticate according to implementation-defined lockout semantics. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDisableUser
```

## Example

```csharp
await disableUser.DisableUserAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DisableUserAsync](method-disableuserasync-42.md) | Disables the specified user. Use it with the surrounding package APIs when composing application code. |

