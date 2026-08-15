# PolicyList

<a id="policylist"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyList.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyList.cs#L9)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents a typed named list referenced by policy conditions. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class PolicyList
```

## Example

```csharp
var list = new PolicyList
{
    Name = "Trusted IPs", Type = PolicyListType.IpAddress, IsEnabled = true,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-35.md) | Gets or sets the UTC creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-14.md) | Gets or sets the persisted list identifier. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-30.md) | Gets or sets whether the list definition is enabled for separately implemented evaluation. Use it with the surrounding package APIs when composing application code. |
| [Items](property-items-45.md) | Gets or sets the polymorphic exact and range values contained by the list. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-19.md) | Gets or sets the required list name, limited to 200 characters by the EF model. Use it with the surrounding package APIs when composing application code. |
| [Type](property-type-25.md) | Gets or sets the declared value type interpreted by a separately implemented evaluator. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-40.md) | Gets or sets the UTC last-update timestamp. Use it with the surrounding package APIs when composing application code. |

