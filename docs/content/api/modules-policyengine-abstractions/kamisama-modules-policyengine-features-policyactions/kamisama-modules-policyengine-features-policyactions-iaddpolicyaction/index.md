# IAddPolicyAction

<a id="iaddpolicyaction"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Interface`

## Description

Defines creation of a reusable action definition. Core checks name duplication and stores handler/configuration text but does not resolve or execute a handler.

## Declaration

```csharp
public interface IAddPolicyAction : IAddFeature<AddPolicyActionRequest, PolicyActionDto>;
```

## Example

```csharp
PolicyActionDto action = await addAction.AddAsync(new AddPolicyActionRequest(
    "Premium plan", "service-plan", configurationSource, false, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

