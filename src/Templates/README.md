# KamiSama Templates

Install the package and list the seven templates:

```console
dotnet new install KamiSama.Templates
dotnet new list kamisama
```

The package contains exactly these .NET 10 templates:

| Short name | Purpose |
| --- | --- |
| `kamisama-solution` | Solution shell, optional `props.xml`, and reusable agent guidance |
| `kamisama-admin` | Hosted Blazor administration solution with reusable bootstrap composition |
| `kamisama-empty` | Minimal class library |
| `kamisama-bounded-context` | Independent Abstractions and provider-neutral Core projects |
| `kamisama-database-support` | Explicit provider project for an existing Core project |
| `kamisama-bootstrap` | Shared Identity and Ticketing composition-root class library |
| `kamisama-orchestration` | Canonical platform Abstractions/Core source with optional hosting |

All project templates use local `net10.0` properties by default. Pass `--UseProps true --PropsPath <path-to-props.xml>` to opt into shared properties.
