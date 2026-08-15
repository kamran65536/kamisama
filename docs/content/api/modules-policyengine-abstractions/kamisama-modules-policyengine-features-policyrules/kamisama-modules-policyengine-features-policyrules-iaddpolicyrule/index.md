# IAddPolicyRule

<a id="iaddpolicyrule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Interface`

## Description

Defines creation of an ordered rule definition. Core stores condition source as opaque text and does not parse or evaluate it.

## Declaration

```csharp
public interface IAddPolicyRule : IAddFeature<AddPolicyRuleRequest, PolicyRuleDto>;
```

## Example

```csharp
PolicyRuleDto rule = await addRule.AddAsync(new AddPolicyRuleRequest(
    "Trusted network", 10, conditionSource, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

