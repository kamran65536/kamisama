# Sessions

[Back to ApplicationUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Entities/ApplicationUser.cs#L17)

Type: `KamiSama.Modules.Identity.Entities.ApplicationUser`

Kind: `Property`

## Description

Gets or sets the sessions associated with this user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual ICollection<ApplicationSession> Sessions { get; set; } = [];
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `ICollection<ApplicationSession>` value. |

## Example

No concise standalone example is available yet.

