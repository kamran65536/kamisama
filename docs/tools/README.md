# Documentation Generator

Run from the repository root:

```powershell
dotnet run --project .\docs\tools\ApiDocGenerator\ApiDocGenerator.csproj
```

Use `--dry-run` to list included and excluded projects without writing generated Markdown.

By default the generated docs use package version `10.0.10`. Set `KAMISAMA_DOCS_VERSION` before generation to override the version stamped into the docs home, API index, and package overview pages:

```powershell
$env:KAMISAMA_DOCS_VERSION = "10.0.11-preview"
dotnet run --project .\docs\tools\ApiDocGenerator\ApiDocGenerator.csproj
python -m mkdocs build --strict
```
