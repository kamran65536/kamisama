# IDeletePolicyRule

<a id="ideletepolicyrule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Features.cs#L23)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Interface`

## Description

Defines deletion of a rule definition by `Guid`. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.

## Declaration

```csharp
public interface IDeletePolicyRule : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteRule.DeleteAsync(ruleId, cancellationToken);
// Current Core registration for this contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

