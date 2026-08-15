# AddOption<TOption>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L32)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Adds an options configuration delegate to the service collection. The delegate runs when &lt;typeparamref name=&quot;TOption&quot;/&gt; is resolved through the options infrastructure.

## Declaration

```csharp
public void AddOption<TOption>(Action<TOption> configure)
    where TOption : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TOption` | The options class to configure. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<TOption>` | `-` | The delegate that mutates each created options instance. |

## Example

```csharp
builder.AddOption<ProductOptions>(options => options.PageSize = 20);
```

