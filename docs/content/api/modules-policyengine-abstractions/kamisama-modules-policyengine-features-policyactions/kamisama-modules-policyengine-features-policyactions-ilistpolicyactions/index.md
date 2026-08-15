# IListPolicyActions

<a id="ilistpolicyactions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs#L8)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Interface`

## Description

Defines paged policy-action definition listing. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.

## Declaration

```csharp
public interface IListPolicyActions : IListFeature<PolicyActionListItemDto, PolicyActionSearchModel>;
```

## Example

```csharp
PagedResult<PolicyActionListItemDto> actions = await listActions.ListAsync(
    new PolicyActionSearchModel(1, 20, null, "service-plan", true, "name"),
    cancellationToken);
// Current Core registration for this contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

