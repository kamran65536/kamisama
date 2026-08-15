# AddPolicyListRequest

<a id="addpolicylistrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs:66](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L66)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Record`

## Description

Supplies the values stored for a new policy-list definition; no item CRUD contract is provided. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddPolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L66)

Supplies the values stored for a new policy-list definition; no item CRUD contract is provided. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddPolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The list name, which Core checks for a case-insensitive duplicate. |
| `Type` | `PolicyListType` | `-` | The declared type of values intended for the list. |
| `IsEnabled` | `bool` | `-` | Whether the new definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

