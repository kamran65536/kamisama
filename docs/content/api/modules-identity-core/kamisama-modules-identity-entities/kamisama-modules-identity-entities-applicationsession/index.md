# ApplicationSession

<a id="applicationsession"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationSession.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationSession.cs#L9)

Namespace: `KamiSama.Modules.Identity.Entities`

Kind: `Class`

## Description

Persistent revocable authentication session. Validation updates and saves `LastConnection`, producing database writes on authenticated traffic.

## Declaration

```csharp
public class ApplicationSession
```

## Example

```csharp
var session = new ApplicationSession
{
    Id = Guid.NewGuid(),
    UserId = user.Id,
    SessionKey = Convert.ToHexString(RandomNumberGenerator.GetBytes(32)),
    DeviceModel = "Web browser",
    IpAddress = "203.0.113.10",
    IsRevoked = false,
    CreatedAt = DateTime.UtcNow,
    LastConnection = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-36.md) | Gets or sets the UTC creation time. Use it with the surrounding package APIs when composing application code. |
| [DeviceModel](property-devicemodel-25.md) | Gets or sets the captured device description. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-12.md) | Gets or sets the database identifier. Use it with the surrounding package APIs when composing application code. |
| [IpAddress](property-ipaddress-29.md) | Gets or sets the captured IP address. Use it with the surrounding package APIs when composing application code. |
| [IsRevoked](property-isrevoked-33.md) | Gets or sets whether the session has been revoked. Use it with the surrounding package APIs when composing application code. |
| [LastConnection](property-lastconnection-39.md) | Gets or sets the last recorded UTC connection time. Use it with the surrounding package APIs when composing application code. |
| [RevokedAt](property-revokedat-42.md) | Gets or sets the UTC revocation time, or while active. Use it with the surrounding package APIs when composing application code. |
| [SessionKey](property-sessionkey-21.md) | Gets or sets the unique key embedded in authentication state. Use it with the surrounding package APIs when composing application code. |
| [User](property-user-18.md) | Gets or sets the owning user navigation. Use it with the surrounding package APIs when composing application code. |
| [UserId](property-userid-15.md) | Gets or sets the owning user&apos;s identifier. Use it with the surrounding package APIs when composing application code. |

