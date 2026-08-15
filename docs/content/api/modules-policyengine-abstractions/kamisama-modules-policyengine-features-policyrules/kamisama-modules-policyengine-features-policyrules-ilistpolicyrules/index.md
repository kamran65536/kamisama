# IListPolicyRules

<a id="ilistpolicyrules"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs#L8)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Interface`

## Description

Defines paged policy-rule definition listing without condition source. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.

## Declaration

```csharp
public interface IListPolicyRules : IListFeature<PolicyRuleListItemDto, PolicyRuleSearchModel>;
```

## Example

```csharp
PagedResult<PolicyRuleListItemDto> rules = await listRules.ListAsync(
    new PolicyRuleSearchModel(1, 20, null, true, "processorder"), cancellationToken);
// Current Core registration for this contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

