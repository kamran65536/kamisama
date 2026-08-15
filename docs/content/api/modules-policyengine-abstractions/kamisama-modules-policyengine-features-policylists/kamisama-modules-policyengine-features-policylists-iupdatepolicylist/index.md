# IUpdatePolicyList

<a id="iupdatepolicylist"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs#L18)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Interface`

## Description

Defines replacement of a list definition by `Guid`. Changing its declared type does not convert existing item rows.

## Declaration

```csharp
public interface IUpdatePolicyList : IUpdateFeature<UpdatePolicyListRequest, Guid>;
```

## Example

```csharp
await updatePolicyList.UpdateAsync(listId,
    new UpdatePolicyListRequest("Trusted IPs", PolicyListType.IpAddress, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

