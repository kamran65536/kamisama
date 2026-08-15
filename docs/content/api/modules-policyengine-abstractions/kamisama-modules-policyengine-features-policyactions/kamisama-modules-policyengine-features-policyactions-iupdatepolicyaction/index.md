# IUpdatePolicyAction

<a id="iupdatepolicyaction"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs#L18)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Interface`

## Description

Defines replacement of an action definition by `Guid`. Core checks the replacement name and saves immediately.

## Declaration

```csharp
public interface IUpdatePolicyAction : IUpdateFeature<UpdatePolicyActionRequest, Guid>;
```

## Example

```csharp
await updateAction.UpdateAsync(actionId, new UpdatePolicyActionRequest(
    "Premium plan", "service-plan", configurationSource, false, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

