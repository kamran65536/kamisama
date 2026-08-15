# PolicyAction

<a id="policyaction"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyAction.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyAction.cs#L8)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents a reusable policy action resolved through a registered action handler. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class PolicyAction
```

## Example

```csharp
var action = new PolicyAction
{
    Name = "Premium plan", HandlerName = "service-plan", ConfigurationSource = configurationSource,
    AllowsMultiple = false, IsEnabled = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [AllowsMultiple](property-allowsmultiple-35.md) | Gets or sets whether a separately implemented evaluator may retain multiple resolutions of this action. Use it with the surrounding package APIs when composing application code. |
| [ConfigurationSource](property-configurationsource-30.md) | Gets or sets opaque configuration text for a separately implemented action handler. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-45.md) | Gets or sets the UTC creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [HandlerName](property-handlername-24.md) | Gets or sets the required application-defined handler name, limited to 200 characters. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-13.md) | Gets or sets the persisted action identifier. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-40.md) | Gets or sets whether the action definition is enabled for separately implemented evaluation. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-18.md) | Gets or sets the required action name, limited to 200 characters by the EF model. Use it with the surrounding package APIs when composing application code. |
| [PolicyRuleActions](property-policyruleactions-55.md) | Gets or sets the rule assignments that reference this action. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-50.md) | Gets or sets the UTC last-update timestamp. Use it with the surrounding package APIs when composing application code. |

