# IUpdatePolicyRule

<a id="iupdatepolicyrule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs#L18)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Interface`

## Description

Defines replacement of a rule definition by `Guid`. Core stores the replacement condition source without validation.

## Declaration

```csharp
public interface IUpdatePolicyRule : IUpdateFeature<UpdatePolicyRuleRequest, Guid>;
```

## Example

```csharp
await updateRule.UpdateAsync(ruleId,
    new UpdatePolicyRuleRequest("Trusted network", 10, conditionSource, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

