# IFindPolicyRuleById

<a id="ifindpolicyrulebyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs#L28)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Interface`

## Description

Defines lookup of one complete rule definition by `Guid`. The returned DTO includes opaque condition source but no action assignments.

## Declaration

```csharp
public interface IFindPolicyRuleById : IFindByIdFeature<PolicyRuleDto, Guid>;
```

## Example

```csharp
PolicyRuleDto rule = await findRule.FindByIdAsync(ruleId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

