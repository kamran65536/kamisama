# EvaluationDiagnostics

[Back to PolicyContext](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs#L25)

Type: `KamiSama.Modules.PolicyEngine.Contexts.PolicyContext`

Kind: `Property`

## Description

Gets the diagnostics produced while evaluating policies. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public IList<PolicyEvaluationDiagnostic> EvaluationDiagnostics { get; } = [];
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `IList<PolicyEvaluationDiagnostic>` value. |

## Example

No concise standalone example is available yet.

